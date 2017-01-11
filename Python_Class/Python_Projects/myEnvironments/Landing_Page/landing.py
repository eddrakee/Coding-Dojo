from flask import Flask, render_template

app = Flask(__name__)

@app.route("/")

def landing():
	return render_template("index.html")


@app.route('/ninja')
def showNinja():
  return render_template('ninja.html')

@app.route('/dojos/new')
def showDojo():
  return render_template('dojo.html')

app.run(debug=True)