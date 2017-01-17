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
    query = "INSERT users (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
    data = {
        'email': request.form['email']
    }
   
    at_counter = 0
    dot_counter = 0

    for key in data.items(): #.items() allow us to look at our values in the data dictionary
        for i in key[1]:
            print i
            if i == "@":
                at_counter = at_counter + 1
                print "at_counter",at_counter
            if i == ".":
                dot_counter = dot_counter + 1

                print "dot_counter", dot_counter
    if dot_counter != 1 or at_counter !=1:
        print "error!"
        return invalid_email()
    else:
        mysql.query_db(query, data)

    return redirect("/")

@app.route('/invalid')
def invalid_email():
    return render_template('bademail.html')



app.run(debug=True)