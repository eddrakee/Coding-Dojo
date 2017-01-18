from flask import Flask, render_template, redirect, request, flash, session
from mysqlconnection import MySQLConnector

#updated bcrypt
from flask_bcrypt import Bcrypt

#import regex
import re 

app = Flask (__name__)
mysql = MySQLConnector(app, 'login_reg')
#flash is apart of session and requires a secret_key
app.secret_key = "thisismysecretkey"

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

#allows bcrypt to be used within the app
bcrypt = Bcrypt(app)

name = re.compile(r'^[a-zA-z]')

@app.route('/')
def index():
    print "a"
    return render_template('index.html')

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
        return redirect('/login_info')

    return redirect('/')

@app.route('/login_info')
def login_info():
    print "c"
    return render_template ('login_info.html')

@app.route('/login', methods = ['POST'])
def login():
    error = 0

    query = "SELECT id, password FROM users WHERE email = '{}'".format(request.form["email"])
    user = mysql.query_db(query)
    print user


    if len(user) < 1:
        flash("Email doesn't exist!")
        error += 1
    elif bcrypt.check_password_hash(user[0]['password'], request.form['password']):
        flash('Password is incorrect')
        error +=1
    elif error == 0:  
        session['id'] = user[0]['id']  
        return redirect('/login_info')



    return redirect('/')

app.run(debug=True)