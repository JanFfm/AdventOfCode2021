


input_file = open('input3.txt', 'r')
bit_strings = []
for l in input_file:
    bit_strings.append(l.split('\n')[0])


gamma_rate = ""
epsilon_rate = ""
string_len = len(bit_strings[0])
counter_one = [0 for i in range(string_len)]
counter_zero = [0 for i in range(string_len)]

#most common bit in each position:
for bit_string in bit_strings:
    for i in range(string_len):
        if int(bit_string[i]) == 1:
            counter_one[i] = counter_one[i] +1
        else:
            counter_zero[i] = counter_zero[i] +1

#calc gamma rate & epsilon rate:
for one, zero in zip(counter_one, counter_zero):
    if one > zero:
        gamma_rate = gamma_rate + "1"
        epsilon_rate  = epsilon_rate  + "0"
    else:
         gamma_rate = gamma_rate + "0"
         epsilon_rate  = epsilon_rate  + "1"
print("gamma rate binary ",gamma_rate)
print("epsilon rate  binary ", epsilon_rate)
gamma_rate = int(gamma_rate, 2)
epsilon_rate = int(epsilon_rate, 2)
print("gamma rate decimal ",gamma_rate)
print("epsilon rate  decimal ", epsilon_rate)
print ("power consumtion: ", gamma_rate*epsilon_rate)