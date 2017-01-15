from flask import Flask, render_template, request, redirect, session
from random import randrange #this is only imports this function, not the whole random library
app = Flask(__name__)
app.secret_key = "a1b2c3thiskeyissecret" 

def Count():
   try:
        session['counter'] += 1
   except KeyError:
        session['counter'] = 1

@app.route('/')
def displayNum():
  Count()
  if (session["counter"]==1):
    session["class"]="clear"
  if "randomNum" not in session:
    session["randomNum"] = randrange(0,101) #since we said from random import randrange, we don't need to used random.randrange...
  #the line above guarantees that a new random number will not be generated everytime the page is refreshed. If it was a variable instead of a session, it would be
  return render_template("index.html")






    
@app.route('/guess', methods=["POST"]) #we need to reroute to a different page since we don't want to post to the main route
def guessNum():
  session["myGuess"] = int(request.form["myGuess"])
  if session["randomNum"] == session["myGuess"] 
     
  return redirect('/')

@app.route('/reset', methods=["POST"])
def playAgain():
  session["randomNum"] = randrange(0,101)
  return redirect('/')



@app.route('/clear', methods = ["POST"])
def clear():
    session.clear()
    return redirect('/')


app.run(debug=True)