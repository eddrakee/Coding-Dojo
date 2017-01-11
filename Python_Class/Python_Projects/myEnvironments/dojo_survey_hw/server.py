from flask import Flask, render_template, request, redirect
app = Flask(__name__)
# our index route will handle rendering our form
@app.route('/')
def index():
  return render_template("index.html")

@app.route('/users', methods=['POST'])
def create_user():
   print "Got Post Info"

   name = request.form['name']
   location = request.form['location']
   language = request.form['language']
   comment = request.form['comment']

   # redirects back to the '/' route
   return redirect('/') #redirects back to the '/' route

@app.route('/result')
def getResult():
  return render_template("result.html")

app.run(debug=True) # run our server