with open("INPUT.TXT", "r") as input_file:
    a = int(input_file.readline().strip())
    b = int(input_file.readline().strip())

if a < b:
    result = "<"
elif a > b:
    result = ">"
else:
    result = "="

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(result)

