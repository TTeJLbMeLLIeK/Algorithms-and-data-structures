# https://acmp.ru/index.asp?main=task&id_task=195
with open("INPUT.TXT", "r") as input_file:
    N, A, B = map(int, input_file.read().split())

area_per_panel = A * B

total_area = N * area_per_panel * 2

required_sulfide = total_area

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(str(required_sulfide))
