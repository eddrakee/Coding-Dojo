from django.shortcuts import render, HttpResponse, redirect
from .models import Book

# Create your views here.

def books_index (request):
    context = {
        'all_books': Book.objects.all()
    }
    return render(request, 'books_app/book_wall.html', context)

def add_book(request):
    Book.objects.add_book(request.POST)
    pass