# PART 1
# Create a class called  Car. In the__init__(), allow the user to specify 
# the following attributes: price, speed, fuel, mileage. 
# If the price is greater than 10,000, set the tax to be 15%. 
# Otherwise, set the tax to be 12%. 

class Car:
    def __init__(self, price, speed, fuel, mileage):
        self.speed = speed
        self.fuel = fuel
        self.price = price
        self.mileage = mileage
    
        if self.price > 10000:
            self.tax = 15
        else:
            self.tax = 12
        
        if self.fuel == 100:
            self.fuel = "Full"
        elif self.fuel >75 and self.fuel <100:
            self.fuel = "Kinda Full"
        elif self.fuel >=50 and self.fuel <75:
            self.fuel = "Not Full"
        else: 
            self.fuel >=0 and self.fuel <50
            self.fuel = "Empty"
        self.displayInfo()

    def displayInfo(self):
        print "Price:", str(self.price)
        print "Speed:", str(self.speed) + "mph"
        print "Fuel:", str(self.fuel)
        print "Mileage:", str(self.mileage) +"mpg"
        print "Tax:", str(self.tax)

# PART 2
# Create six different instances of the class Car. In the class have a method called display_all() that returns 
# all the information about the car as a string. In your __init__(), call this display_all() method to display 
# information about the car once the attributes have been defined.

Vroom1 = Car(2000, 35, 100, 15)
Vroom2 = Car(2000, 5, 60, 105)
Vroom3 = Car(2000, 25, 80, 95)
Vroom4 = Car(2000, 25, 100, 25)
Vroom5 = Car(2000, 45, 5, 25)
Vroom6 = Car(20000000, 35, 0, 15)


#I don't need to use the code below because I called self.displayInfo() in the __init__ function. 
#If not, I would have to use the commands below:

# print "- Car 1 -"
# Vroom1.displayInfo()
# print "- Car 2 -"
# Vroom2.displayInfo()
# print "- Car 3 -"
# Vroom3.displayInfo()
# print "- Car 4 -"
# Vroom4.displayInfo()
# print "- Car 5 -"
# Vroom5.displayInfo()
# print "- Car 6 -"
# Vroom6.displayInfo()


# ANSWER KEY

# class Car(object):
#     def __init__(self, price, speed, fuel, mileage):
#         self.speed = speed 
#         self.fuel = fuel
#         self.mileage = mileage
#         self.price = price
#         if price > 10000:
#            self.tax = .15
#         else:
#             self.tax = .12
#         self.display_all()

#     def display_all(self):
#         print 'Price: ' + str(self.price)
#         print 'Speed: ' + str(self.speed) + 'mph'
#         print 'Fuel: ' + self.fuel
#         print 'Mileage: ' + str(self.mileage) + 'mpg'
#         print 'Tax: ' + str(self.tax)
        
# car1 = Car(2000, 35, 'Full', 15)
# car2 = Car(2000, 5, 'Not Full', 105)
# car3 = Car(2000, 15, 'Kind of Full', 95)
# car4 = Car(2000, 25, 'Full', 25)
# car5 = Car(2000, 45, 'Empty', 25)
# car6 = Car(20000000, 35, 'Empty', 15)