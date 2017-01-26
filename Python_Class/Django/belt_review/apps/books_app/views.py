from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from ..log_reg.models import User
from .models import Book

# Create your views here.
def book_index(request):
    context = {
        'total_books': Book.objects.all()
    }
    # Book.objects.create(author="Joan Didion", title="Slouching Towards Bethelham")
    return render(request, 'books_app/book_wall.html', context)

def create_book(request):
    # Book.objects.add_book(request.POST)
    return redirect('books_ns:book_index')

    