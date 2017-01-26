from django.shortcuts import render
from django.contrib import messages

# Create your views here.
def wall(request):
   #will add context
   print ("hello")*50
   return render(request, 'posts/wall.html')
    