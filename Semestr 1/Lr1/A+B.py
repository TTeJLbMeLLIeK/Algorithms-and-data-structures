# https://acmp.ru/index.asp?main=task&id_task=1
with open("INPUT.TXT", "r") as input_file:
    a, b = map(int, input_file.read().split())

result = a + b

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(str(result))
