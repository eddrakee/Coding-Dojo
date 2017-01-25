from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User

# Create your views here.
def index(request):
    context = {
        'all_users': User.objects.all()
    }
    return render(request, 'log_reg/index.html', context)

def register(request):
    error_arr_message = User.objects.validate(request.POST)
    #this is going to use the validate method in UserManager to make the request.POST above our postData1
    #error_arr_message will now equal error_arr in UserManager/validate

    if len(error_arr_message) > 0:
        for message in error_arr_message:
            messages.add_message(request, messages.ERROR, message)
        return redirect ('/')
    User.objects.register(request.POST) #pass the POST dictionary to the UserManager register method
    request.session['user_id'] = User.objects.set_session(request.POST) #this will log in the user without making go through the login form
    print (request.session['user_id']) 
    return redirect ('/success') #reroute to my success page

def login(request):
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
    return redirect('/success') #reroute to my success page

def success(request):
    print('They have now logged in!')
    return render(request, 'log_reg/logged_in.html')

def logout(request):
    request.session.flush() #this clears all the sessions!
    return redirect('/')

