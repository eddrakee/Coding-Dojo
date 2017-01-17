from flask import Flask, render_template, redirect, request, flash, session
from mysqlconnection import MySQLConnector
#updated bcrypt
from flask_bcrypt import Bcrypt
import re

app = Flask (__name__)
mysql = MySQLConnector(app, 'login_reg')
#flash is apart of session and requires a secret_key
app.secret_key = "thisismysecretkey"

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

#allows bcrypt to be used within the app
bcrypt = Bcrypt(app)

@app.route('/')
def index():
    return render_template('index.html')




app.run(debug=True)