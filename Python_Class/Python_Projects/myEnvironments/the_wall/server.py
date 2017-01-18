from flask import Flask, render_template, redirect, request, flash, session
from mysqlconnection import MySQLConnector

#updated bcrypt
from flask_bcrypt import Bcrypt

#import regex
import re 

app = Flask (__name__)
mysql = MySQLConnector(app, 'wall')
#flash is apart of session and requires a secret_key
app.secret_key = "thisismysecretkey"

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

#allows bcrypt to be used within the app
bcrypt = Bcrypt(app)

name = re.compile(r'^[a-zA-z]')

#login_registration code
@app.route('/')
def index():
    # if not 'user_id' in session:
    #     session['user_id'] = None
    print "a"
    return render_template('index.html')

#this is where you register
@app.route('/register', methods=['POST'])
def register():
    print "b"
    error = 0
    if len(request.form['first_name'])<2:
        error += 1
        flash("your name needs more characters!")
    elif not name.match(request.form['first_name']):
        error +=1
        flash("no numbers are allowed in your name")

    if len(request.form['last_name'])<2:
        error += 1
        flash("need more characters!")
    elif not name.match(request.form['last_name']):
        error +=1
        flash("no numbers are allowed in your name")
    
    if not EMAIL_REGEX.match(request.form['email']):
        error +=1
        flash('email is not valid!')
    if len(request.form['password']) < 9:
        error += 1
        flash ("password needs to be 9 characters or more!")
    
    if request.form['password'] != request.form['confirm']:
        error += 1
        flash('passwords do not match!')

    if error == 0:
        hashed = bcrypt.generate_password_hash(request.form['password'])
        query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES(:first_name, :last_name, :email, :confirm, NOW(), NOW())"
        data = { 
            'first_name': request.form['first_name'], 
            'last_name': request.form['last_name'], 
            'email': request.form['email'], 
            'confirm': hashed 
        }

        mysql.query_db(query,data)
        return redirect('/success')
        #looks like i don't need /login_info. Because we can change it to /success. 
        #also, we should figure out why the name doesn't show up when they first register

    return redirect('/')

@app.route('/login_info')
def login_info():
    print "c"

    return render_template ('login_info.html')

@app.route('/login', methods = ['POST'])
def login():

    error = 0

    query = "SELECT id, password, first_name FROM users WHERE email = '{}'".format(request.form["email"])
    user = mysql.query_db(query)
    print user


    if len(user) < 1:
        flash("Email doesn't exist!")
        error += 1
    elif not bcrypt.check_password_hash(user[0]['password'], request.form['password']):
        flash('Password is incorrect')
        error +=1
    elif error == 0:  
        session['user_id'] = user[0]['id']  #set your session
        session['name'] = user[0]['first_name'] 
        print user[0]['id']
        print user[0]['first_name']
        return redirect('/login_info')

    return redirect('/')

@app.route('/success')
def success():
    
    query = "SELECT messages.id, messages.message, messages.created_at, users.first_name, users.last_name FROM messages JOIN users on users.id = messages.user_id"
    all_messages = mysql.query_db(query) #list of objects returned
    
    query2 = "SELECT comments.message_id, comments.comment, comments.created_at, users.first_name, users.last_name FROM comments JOIN users on users.id = comments.user_id"
    all_comments = mysql.query_db(query2) #list of objects returned
    return render_template('login_info.html', messages = all_messages, comments = all_comments)


#code for messages - the first function actually will be the wall with all the messages and comments, and then the posting of messages later

@app.route('/message', methods=['POST'])
def message():
    
    print request.form
    print session
    query = "INSERT into messages (message, user_id, created_at, updated_at) VALUES (:content, :user_id, NOW(), NOW())"
    values = {
         "content": request.form["content"], 
         "user_id": session["user_id"]
        
    }
    print session['user_id']
    # #  ('/wall) return render_template("wall.html, first_name = fname[0]['first_name']")
    mysql.query_db(query, values)
    return redirect('/success')

@app.route('/comment/<message_id>', methods = ['POST'])
def comment(message_id):
    print "comment"

    query = "INSERT into comments (comment, user_id, message_id, created_at, updated_at) VALUES (:commentcontent, :user_id, :message_id, NOW(), NOW())"
    values = {
        "commentcontent": request.form["content"], 
        "user_id": session["user_id"],
        "message_id": message_id
    }
    mysql.query_db(query, values)
    return redirect('/success')

@app.route('/logout', methods=["POST"])
def logout():
    session.clear()
    return redirect('/')



app.run(debug=True)