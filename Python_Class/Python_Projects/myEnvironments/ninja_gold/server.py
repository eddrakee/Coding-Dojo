from flask import Flask, render_template, request, redirect, session
from random import randrange #this is only imports this function, not the whole random library
app = Flask(__name__)
app.secret_key = "a1b2c3thiskeyissecret" 


@app.route('/')
def index():
  if "gold" not in session:
    session["gold"] = 0

  if "activities" not in session:
    session["activities"] = []
  return render_template("index.html")

@app.route('/process', methods=["POST"])
def process():
  buildings = {
    "Farm": randrange(10,21),
    "Cave": randrange(5,11),
    "House": randrange(2,6),
    "Casino": randrange(0,51)
  }
  return redirect("index.html")



app.run(debug=True)