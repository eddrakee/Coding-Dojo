'''Create a function that counts from 1 to 2000. As it loops through each number, 
have your program generate the number and specify whether it's odd or even'''

def nameNum():
    for count in range(1, 2001):
        if count%2 == 0:
            print "Number is" , str(count)+"." , "This is an odd number."
        else:
            print "Number is" , str(count)+"." , "This is an even number."
nameNum()


"""
ANSWER:
for i in range(1,2001):
    if i % 2 == 0:
        print 'Number is ' + str(i) + '. This is an odd number.'
    else:
        print 'Number is ' + str(i) + '. This is an even number.'
        """