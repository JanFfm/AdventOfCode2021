
def sort_list(list, bit_position,  most_common_value :bool ):   
    list_lenght= len(list) 
    if list_lenght == 1:
        return list
    else:
        ones_list = []
        zeros_list = []
        for j in range(list_lenght-1, -1, -1):   
            if list[j][bit_position] =='1':
                  ones_list.append(list[j])
            else:
                zeros_list.append(list[j])

        if len(ones_list) > len(zeros_list): 
            print("one is more significant in position ", i)       
            most_common_value_list = ones_list
            least_common_value_list = zeros_list
        elif len(ones_list) == len(zeros_list): 
            print("one is equal significant to zero in position ", i)       
            
            most_common_value_list = ones_list
            least_common_value_list = zeros_list
           
        else:
            print("zero is more significant in position ", i)       

            most_common_value_list = zeros_list
            least_common_value_list = ones_list
        if most_common_value:
            return most_common_value_list
        else:
            return least_common_value_list


input_file = open('input3.txt', 'r')

ones_list = []
zeros_list = []
for l in input_file:
    l = l.split('\n')[0]
    if l[0] == '1':
        ones_list.append(l)
    else:
        zeros_list.append(l)
if len(ones_list) >= len(zeros_list) :        
    oxygen_list = ones_list
    co2_list = zeros_list
else:
    oxygen_list = zeros_list
    co2_list = ones_list
lists = [oxygen_list, co2_list]
switch = [True, False]
print(lists)

results = []

for list, s in zip(lists, switch):
    bit_positions = len(list[0])
    for i in range(1,bit_positions):
        # one list at bit-position i for oxygen (s=True) or co2 (s=False)
        list = sort_list(list, i, s)
        print(list)
        if len(list) == 1:
            results.append(list[0])
            break
    print("###################")

print(results)
oxygen_generator_rating = int(results[0], 2)
co2_scrubber_rating = int(results[1], 2)

print(oxygen_generator_rating, " * ", co2_scrubber_rating, " = " , oxygen_generator_rating*co2_scrubber_rating)





