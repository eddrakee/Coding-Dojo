from __future__ import unicode_literals

from django.db import models
from ..log_reg.models import User
# Create your models here.

class BookManager(models.Manager):
    def add_book(self, postData):
        print ("Make a book method called!")
        #just getting the whole Review object via id
        # review_var.user.id #the id for the user who wrote the review
        new_book = self.create(author=postData['author'], title=postData['title']) #make a book!
        return(new_book)


class Book(models.Model):
        author_name = models.CharField(max_length=255) #each field is an attribute
        title = models.CharField(max_length=255)
        created_at = models.DateTimeField(auto_now_add = True)
        updated_at = models.DateTimeField(auto_now = True)

        #don't forget to connect this to our BookManager!
        objects = BookManager()



class ReviewManager(models.Manager):
    def create_review(self, postData, book_id, user_id):
        print("Create a review method has been called!")

        user = User.objects.user.get(id=user_id)
        book = Book.objects.book.get(id=book_id)
        new_review = self.create(
            content=postData['content'], 
            rating=postData['rating'], 
            book=book.id, 
            user=user.id
            )
        return(new_review)


class Review(models.Model):
        rating= models.IntegerField( )
        content = models.TextField(max_length=500)
        book = models.ForeignKey(Book, related_name = "added_book" )
        user = models.ForeignKey(User, related_name = "review_user"  )
        created_at = models.DateTimeField(auto_now_add = True)
        updated_at = models.DateTimeField(auto_now = True)

        #don't forget to connect this to our ReviewManager!
        objects = ReviewManager()