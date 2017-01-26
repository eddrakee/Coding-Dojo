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
    pass
 

def login(request):
    User.objects.login(request.POST)
    pass
