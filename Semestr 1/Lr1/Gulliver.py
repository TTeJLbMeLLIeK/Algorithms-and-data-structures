# https://acmp.ru/index.asp?main=task&id_task=773
with open("INPUT.TXT", "r") as input_file:
    K, M = map(int, input_file.read().split())

mattresses_per_layer = K ** 2

total_mattresses = mattresses_per_layer * M

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(str(total_mattresses))
