from django.conf.urls import url, include
from . import views


urlpatterns = [
    url(r'^$', views.books_index, name='books_index'),#get
    url(r'^add/(?P<user_id>\d+)$', views.add_book, name='books_add'),#post method, it will not show this page
    url(r'^(?P<book_id>\d+)$', views.show_book, name='books_show'),
    
    # url(r'^add_review/(?P<book_id>\d+)/(?P<user_id>\d+)$', views.add_review, name='reviews_add'),
    
  
]