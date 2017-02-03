from django.shortcuts import render, HttpResponse, redirect
from .models import User

# Create your views here.

def user_index (request):
    context = {
        'all_users': User.objects.all()
    }
    return render(request, 'login_app/index.html', context)

def register(request):
    User.objects.register(request.POST)
    user = User.objects.get(email='{}'.format(request.POST['email'])) #this gets the instance of user that just logged in
    request.session['user_id']=user.id
    request.session['user_name']=user.first_name #this sets out session
    return redirect ('books_ns:books_index')
 

def login(request):
    User.objects.login_user(request.POST)
    user = User.objects.get(email='{}'.format(request.POST['email'])) #this gets the instance of user that just logged in
    request.session['user_id']=user.id
    request.session['user_name']=user.first_name #this sets out session
    return redirect ('books_ns:books_index')

def profile(request, user_id):
    user = User.objects.get(id=request.session['user_id'])
    context ={
        'all_users': User.objects.all(),
        'user_info' : user
    }
    
    return render(request, 'login_app/profile.html', context)