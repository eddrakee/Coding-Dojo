from flask import Flask, render_template, request, redirect, session
# import the Connector function
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key = 'eliseisthebest'
# connect and store the connection in "mysql" note that you pass the database name to the function
mysql = MySQLConnector(app, 'world')
# an example of running a query
# print mysql.query_db("INSERT INTO countries (name) VALUES '{$_SESSION['enterCountry']}'")
# app.run(debug=True)

@app.route('/')
def enterCountry():
    
    acountry = mysql.query_db("SELECT name from cities WHERE name = 'myCity'")
    # acountry = mysql.query_db("SELECT name FROM countries")
    print acountry
    return render_template('index.html', zebra=acountry)

@app.route('/   ', methods=['POST'])
def displayCountry():
    data = {
        'name': request.form['myCity'],
        'country_code' : request.form['country_code'],
        'district' : request.form['district'],
        'population' : request.form['population']
    }
    query = """INSERT INTO cities (name, country_code, district, population) VALUE (:myCity, :country_code, :district, :population)"""
    print mysql.query_db(query, data)

    return redirect ("/")

app.run(debug=True) # run our server



