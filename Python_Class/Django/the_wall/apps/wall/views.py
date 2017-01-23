from django.shortcuts import render, redirect, HttpResponse
from . models import User, Message, Comment
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

name = re.compile(r'^[a-zA-Z]') 

# Create your views here.
def index(request):
    print "index"
    context = {
        'users': User.objects.all()
    }
    return render(request,'wall/index.html', context)

def register(request):
    print"register"
    if request.method == 'POST':
        error = 0 #create this variable so if error is increased, we do not set sessions and do not let the user register
        if len(request.POST['first_name']) < 2: #this matches the name='first_name' field in index.html
            error += 1
            print "First Name needs more characters!"
        elif not name.match(request.POST['first_name']): #this refers to the "name" variable under EMAIL_REGEX
            error += 1
            print "First Name cannot have numbers!"
        if len(request.POST['last_name']) < 2: 
            error += 1
            print "First Name needs more characters!"
        elif not name.match(request.POST['last_name']):
            error += 1
            print "First Name cannot have numbers!"
        if not EMAIL_REGEX.match(request.POST['email']): #if email does not match
            error += 1
            print "Email is not valid!"
        if len(request.POST['password']) < 6:
            error += 1
            print "Password must have 6 characters!"
        if  len(request.POST['password']) is len(request.POST['confirm']):
            error += 1
            print "Passwords do not match!" 
        if error == 0:
            User.objects.create(
                first_name=request.POST['first_name'],
                last_name=request.POST['last_name'],
                email=request.POST['email'],
                password=request.POST['confirm']
                )
        return redirect('/')
def login(request):
    error = 0
    user = User.objects.get(email='{}'.format(request.POST['email'])) #.format let's us use the {}

    if user.password != request.POST['password']: #this calls to the name='password' in the second form
        error += 1
        print "Password is incorrect!"
    elif error == 0:
        request.session['user_id'] = user.id #this let's us create our session as "user_id." It also let's us stay logged in
        request.session['user_name'] = user.first_name
        print request.session['user_id']
        print request.session['user_name']
        return redirect('/success')
    else:
        return redirect('/')

def success(request):
    context = {
        'all_posts' : Message.objects.all(),
        'all_users' : User.objects.all()
    }
    return render (request, 'wall/show.html', context)
