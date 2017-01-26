from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^book_index$', views.book_index, name="book_index"),
    url(r'^$', views.create_book, name="make_book"), 
  

]


# first app namespace = login_ns
# books_ns


            # {% for idx in total_books %}
            #     {% for idx in range (0,3) %}
            #     <li><a href= "{% url 'books_ns:show_book' book_id=book.id %}">{{ idx.name }}</a></li>
            #     <li><a href= "{% url 'login_ns:show_profile' %}">{{ idx.review.user.first_name }}</a> <p>says {{idx.review.rating} {{ idx.review.created_at }}}</p></li>
            #     {% endfor %}
            # {% endfor %}

[[[[[[[[[]]]]]]]]]
        