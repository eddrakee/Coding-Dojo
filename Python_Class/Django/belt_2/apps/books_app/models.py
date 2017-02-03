from __future__ import unicode_literals
import bcrypt
import hashlib
import re
from ..login_app.models import User
from django.db import models

# Create your models here.
class BookManager(models.Manager):
    def add_book(self, postData):
        added_book =self.create( 
            author = postData['author'], 
            title = postData['title']
        )
        print(added_book.id)
        return(added_book.id)

class Book(models.Model):
    author = models.CharField(max_length=100)
    title = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = BookManager()

class ReviewManager(models.Manager):
    def add_review(self, postData, book_id, user_id):
        book = Book.objects.get(id=book_id)
        print (book)
        user = User.objects.get(id=user_id)
        added_review = self.create( 
            content = postData['content'], 
            rating = int(postData['rating']),
            user=user,
            book=book
        )

        return(added_review)

class Review(models.Model):
    content = models.TextField(max_length=1000)
    rating = models.IntegerField()
    user = models.ForeignKey(User, related_name="review_user")
    book = models.ForeignKey(Book, related_name="review_book")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = ReviewManager()