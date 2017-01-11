# from flask import Flask, render_template

# app = Flask(__name__)

# This is for the Hello World example
# @app.route("/")

# def hello_world():
# 	return render_template("index.html", name="Elise")
# app.run(debug=True)

#This is for the Template example
from flask import Flask, render_template

app = Flask(__name__)

@app.route("/")

def hello_world():
	return render_template("index.html", phrase="Hello" , times=5)
app.run(debug=True)
