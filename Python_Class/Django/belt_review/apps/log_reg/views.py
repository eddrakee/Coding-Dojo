from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User

# Create your views here.
def index(request):
    #to make sure a logged in user can't log in again
    if "user_id" in request.session: #this says is the user_id key (from the login method when we set the session) in session?
        messages.add_message(request, messages.ERROR, "You are already logged in!")
        # return redirect('/success') #send them back to the success page so they can't log in again
        pass
    context = {
        'all_users': User.objects.all()
    }
    return render(request, 'log_reg/index.html', context)

def register(request):
    #to make sure a logged in user can't log in again
    if "user_id" in request.session: #this says is the user_id key (from the login method when we set the session) in session?
        messages.add_message(request, messages.ERROR, "You are already logged in!")
        # return redirect('/success') #send them back to the success page so they can't log in again
        pass

    error_arr_message = User.objects.validate(request.POST)
    #this is going to use the validate method in UserManager to make the request.POST above our postData1
    #error_arr_message will now equal error_arr in UserManager/validate

    if len(error_arr_message) > 0: #if my error_arr_message is not empty...
        for message in error_arr_message: #loop through the array and add them all to "messages" and it is what we use in our html
            messages.add_message(request, messages.ERROR, message)
        return redirect ('/')
    User.objects.register(request.POST) #pass the POST dictionary to the UserManager register method
    request.session['user_id'] = User.objects.set_session(request.POST) #this will log in the user without making go through the login form
    print (request.session['user_id']) 
    return redirect ('books_ns:book_index') #reroute to my success page
    

def login(request):
    if "user_id" in request.session: #this says is the user_id key (from the login method when we set the session) in session?
        messages.add_message(request, messages.ERROR, "You are already logged in!")
        return redirect('/success') #send them back to the success page so they can't log in again
        

    login_attempt = User.objects.login_user(request.POST) #this says go to User, then it's objects, then the method login_user
    if not User.objects.email_exist(request.POST): #did they input an email that's in the database?
        messages.add_message(request, messages.ERROR, "Email is incorrect!")
        return redirect('/')
        #now we check to see if the password matches the email with the code below!
    if not login_attempt: #aka if login_attempt == False
        messages.add_message(request, messages.ERROR, "Password is incorrect!")
        return redirect('/')
    #now let's set the session!
    request.session['user_id'] = User.objects.set_session(request.POST) #this sets the session so we can access this user's info as long as they are logged in
    print (request.session['user_id']) #user_id is a key that we just created
    return redirect('books_ns:book_index') #reroute to my success page
    pass

def success(request):
    #if someone goes to /success without logging in first
    if not "user_id" in request.session: #if the id is not logged in
        messages.add_message(request, messages.ERROR, "Please log in first!")
        return redirect('/') #send them back to the success page so they can't log in again
    print('They have now logged in!')
    user_data = User.objects.set_user_session(request.session['user_id']) #same user_id that we declared in register
    print ('- The users database object -') #the object will have keys, and those keys are the same as our class User
    print (user_data)
    print ('- The users database object ID -')
    print (user_data.id)
    return render(request, 'log_reg/logged_in.html')

def logout(request):
    request.session.flush() #this clears all the sessions!
    return redirect('/')

