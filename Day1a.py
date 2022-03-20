
counter= 0

first_run = True
first_depth = 0
input_file = open('input1.txt', 'r')
for l in input_file:
    if first_run:
        first_depth = int(l.split('\n')[0])
        first_run = False
    else:
        depth = l.split('\n')[0]
        if(len(depth) > 0):
            depth=int(depth)
            print(first_depth, depth)
            if depth > first_depth:
                counter +=1
        first_depth = depth
print(counter)
  

