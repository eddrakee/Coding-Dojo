from django.shortcuts import render, redirect, HttpResponse
from . models import Course, Description, Comment
import re

# Create your views here.
def index(request):
    print "show index.html"
    all_the_courses = {
        'all_courses': Course.objects.all(),
    }
    return render(request,'courses/index.html', all_the_courses)

def create_course(request):
    print "create_course"
    error = 0
   
    course = Course.objects.create(course_name=request.POST['course_name'])
    course_id=course.id #we made up course_id, it is taking in the id of the variable course that we just created
    Description.objects.create(content=request.POST['description'], course_id=course_id)

    return redirect('/')

def print_course(request):
    all_the_courses = {
        'all_courses': Course.object.all(),
    }

    return render(request, '/courses/index.html', all_the_courses)

def delete(request, id): #this id is referring to the id in our urls.py and the value comes from index.html on the form action
    if request.method =="POST":
        Course.objects.filter(id=id).delete() #the first id belongs to the Course.objects. The second id is the one being passed through the browser
        Description.objects.filter(id=id).delete()
    return redirect('/')


