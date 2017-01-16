from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'email_validation')

@app.route('/')
def index(): #display the local host
    print "a"
    query = "SELECT * FROM users"
    display = mysql.query_db(query)
    return render_template('index.html', display_all = display) #render_template lets python interpret the html in a way that the client will understand

@app.route('/new_user', methods = ['POST'])
def create_user():
    print "b"
    query = "INSERT users (name, email, created_at, updated_at) VALUES (:name, :email, NOW(), NOW())"
    data = {
        'name': request.form['name'],
        'email': request.form['email']
    }
    mysql.query_db(query,data)
    return redirect('/')

@app.route('/validate')
def check_email():
    data = {
            'name': request.form['name'],
            'email': request.form['email']
        }
    
    at_counter = 0
    dot_counter = 0
    email = request.form['email']
    for i in email:
        if email[i] == "@":
            at_counter = at_counter+1
        if email[i] == ".":
            dot_counter = dot_counter+1
    if at_counter != 1 or dot_counter != 1:
        print"This email is invalid"
    else:
        return redirect('/')
    
mysql.query_db(data)

app.run(debug=True)