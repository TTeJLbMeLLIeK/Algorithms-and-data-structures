with open("INPUT.TXT", "r") as input_file:
    number = input_file.read().strip()

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(number)

