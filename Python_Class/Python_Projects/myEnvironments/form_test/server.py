from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = "ThisIsSecret" # sessions always requires a secret key. you need to set a secret key for security purposes
# routing rules and rest of server.py below
# our index route will handle rendering our form
@app.route('/')
def index():
  return render_template("index.html")
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route
@app.route('/users', methods=['POST'])
def create_user():
   print "Got Post Info"
   # recall the name attributes we added to our form inputs
   # to access the data that the user inputs into the fields we use request.form['name_of_input']
  #  name = request.form['name'] # the variable allows us to store the data that the user inputed
  #  email = request.form['email']
  #  # redirects back to the '/' route
  #  return redirect('/') #redirects back to the '/' route

  # here we add two properties to session to store the name and email
   session['name'] = request.form['name']
   session['email'] = request.form['email']
   return redirect('/show') # noticed that we changed where we redirect to so that we can go to the page that displays the name and email!


@app.route('/show')
def show_user():
  # return render_template('user.html', name=session['name'], email=session['email']) - we can block this out since we added session into our user.html file
  return render_template("user.html")

app.run(debug=True) # run our server