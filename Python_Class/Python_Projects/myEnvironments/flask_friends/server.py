from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')

#def index will render our main page and displays our index.html
@app.route('/')
def index():
    print "a"
    query = "SELECT * FROM friends"                           # define your query
    friends = mysql.query_db(query)                           # run query with query_db()
    return render_template('index.html', all_friends=friends) # pass data to our template


#this will create a friend
@app.route('/friends', methods=['POST'])
    
    #STEP THREE:
def create():
    print "b"
    # Write query as a string. Notice how we have multiple values
    # we want to insert into our query.
    #IMPORTANT: make sure you keep this long query variable in one line otherwise it gets wonky!
    query = "INSERT INTO friends (first_name, last_name, occupation, created_at, updated_at) VALUES (:first_name, :last_name, :occupation, NOW(), NOW())"
    # We'll then create a dictionary of data from the POST data received.
    data = {
             'first_name': request.form['first_name'], 
             'last_name':  request.form['last_name'],
             'occupation': request.form['occupation']
           }
    # Run query, with dictionary values injected into the query.
    mysql.query_db(query, data)
    return redirect('/')


#this function will display one friend at a time
@app.route('/friends/<friend_id>')
def show(friend_id):
    print "c"
    
    # Write query to select specific user by id. At every point where
    # we want to insert data, we write ":" and variable name.
    query = "SELECT * FROM friends WHERE id = :specific_id"
    # Then define a dictionary with key that matches :variable_name in query.
    data = {'specific_id': friend_id}
    # Run query with inserted data.
    friends = mysql.query_db(query, data)
    # Friends should be a list with a single object,
    # so we pass the value at [0] to our template under alias one_friend.

    # return render_template('index.html', one_friend=friends[0])
    return render_template('index.html', one_friend=friends[0])
    # return redirect("/update_friend/<friend_id>")


#this will update our friend's info
@app.route('/update_friend/<friend_id>', methods=['POST'])
def update(friend_id):
    print "d"
    query = "UPDATE friends SET first_name = :first_name, last_name = :last_name, occupation = :occupation WHERE id = :id"
    data = {
             'first_name': request.form['first_name'], 
             'last_name':  request.form['last_name'],
             'occupation': request.form['occupation'],
             'id': friend_id
           }
    mysql.query_db(query, data)
    # return redirect('/')
    return redirect('/show_update/'+friend_id) #redirects to the different function, not a different page

@app.route('/show_update/<friend_id>')
def display_update(friend_id):
    print "e"
    query = "SELECT * FROM friends WHERE id = :specific_id"
    data = {'specific_id': friend_id}
    friends = mysql.query_db(query, data)
    return render_template ('updated_friend.html', update_friend = friends[0], friend_id=friend_id)



@app.route('/remove_friend/<friend_id>', methods=['POST'])
def delete(friend_id):
    print "f"
    query = "DELETE FROM friends WHERE id = :id"
    data = {'id': friend_id}
    mysql.query_db(query, data)
    return redirect('/')

app.run(debug=True)