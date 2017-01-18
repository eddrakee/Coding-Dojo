#define the class Bike
class Bike:
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0

    def displayInfo(self):
        print "This bike costs $" + str(self.price)
        print "This bike can go up to" , str(self.max_speed) + "mph"
        print "This bike has ridden" , str(self.miles) , "miles already!"
    
    def ride(self):
        print "ride away!"
        self.miles += 10
        print "This bike has ridden" , str(self.miles) , "miles already!"
    
    def reverse(self):
        #this prevents mileage from going negative
        if self.miles > 5:
            print "reverse! reverse!"
            self.miles -=5
            print "You went backwards! Your total mileage is now", str(self.miles),"!"
        else:
            self.miles == 0
            print "You can't go negative!"



#create three instances for Bike
bike1 = Bike(35, 70)
bike2 = Bike(200, 90)
bike3 = Bike(50, 60)

#bike1 goes for a ride...make it ride 3 times, then reverse once
bike1.ride()
bike1.ride()
bike1.ride()
bike1.reverse()
bike1.displayInfo()

#bike2 goes for a ride...make it ride 2 times and reverse 2 times
bike2.ride()
bike2.ride()
bike2.reverse()
bike2.reverse()
bike2.displayInfo()

#bike3 goes for a ride...make it reverse three times and make sure it doesn't go negative in mileage

bike3.reverse()
bike3.reverse()
bike3.reverse()
bike3.displayInfo()

#ANSWER KEY

# OOP Bike

# define the Bike class
# class Bike(object):
#     def __init__(self, price, max_speed):
#         self.price = price
#         self.max_speed = max_speed
#         self.miles = 0

#     def displayInfo(self):
#         print 'Price is: $' + str(self.price)
#         print 'Max speed: ' + str(self.max_speed) + 'mph'
#         print 'Total miles: ' + str(self.miles) + ' miles'

#     def drive(self):
#         print 'Driving'
#         self.miles += 10

#     def reverse(self):
#         print 'Reversing'
#         # prevent negative miles
#         if self.miles >= 5:
#             self.miles -= 5

# create instances and run methods
# bike1 = Bike(99.99, 12)
# bike1.drive()
# bike1.drive()
# bike1.drive()
# bike1.reverse()
# bike1.displayInfo()

# bike2 = Bike(139.99, 20)
# bike2.drive()
# bike2.drive()
# bike2.reverse()
# bike2.reverse()
# bik2.displayInfo()



