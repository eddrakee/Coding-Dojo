from django.conf.urls import url, include
from . import views


urlpatterns = [
    url(r'^$', views.books_index, name='books_index'),url(r'^$', views.books_index, name='books_index'),
    url(r'^add$', views.add_book, name='books_add'),
    
  
]