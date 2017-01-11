from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = "ThisIsSecret" 

def visitCounter():
    # try:
      session["count"] += 1
    # except KeyError:
    #   session["count"] =1

@app.route('/')
def index():
    visitCounter()
    return render_template("index.html")

@app.route('/ninja')
def doubleCount():
    session["count"] +=2
    return render_template("index.html")

@app.route('/clear')
def clearCount():
    session["count"] = 0
    return render_template("index.html")

app.run(debug=True)