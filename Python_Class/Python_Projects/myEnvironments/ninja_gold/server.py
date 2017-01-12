from flask import Flask, render_template, request, redirect, session
from random import randrange #this is only imports this function, not the whole random library
app = Flask(__name__)
app.secret_key = "a1b2c3thiskeyissecret" 


@app.route('/')
def displayNum():
  if "randomNum" not in session:
    session["randomNum"] = randrange(0,101) #since we said from random import randrange, we don't need to used random.randrange...
  #the line above guarantees that a new random number will not be generated everytime the page is refreshed. If it was a variable instead of a session, it would be
  return render_template("index.html")

@app.route('/guess', methods=["POST"])
def guessNum():
  session["myGuess"] = int(request.form["myGuess"])
  return redirect('/')

@app.route('/reset', methods=["POST"])
def playAgain():
  session["randomNum"] = randrange(0,101)
  return redirect('/')


app.run(debug=True)