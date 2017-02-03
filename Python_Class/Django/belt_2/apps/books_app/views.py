from django.shortcuts import render, HttpResponse, redirect
from .models import Book, Review
from ..login_app.models import User

# Create your views here.

def books_index (request):
    context = {
        'all_books': Book.objects.all(),
        'all_reviews' : Review.objects.all()
    }
    return render(request, 'books_app/add_book.html', context) 
    # need to check this html page later to make it the book profile page again

def add_book(request, user_id):
    book1 = Book.objects.add_book(request.POST)
    Review.objects.add_review(request.POST, book1, user_id)
    return redirect('/book/'+str(book1)) #for when passing in a parameter in redirect

def show_book(request, book_id):
    review_id = request.session['user_id']
    context = {
        'book_data' : Book.objects.get(id=book_id),
        'review_data': Review.objects.filter(book=Book.objects.get(id=book_id)),
        'user_data': User.objects.get(id=review_id)
    }
    print(context)
    return render(request, 'books_app/book_profile.html', context)

