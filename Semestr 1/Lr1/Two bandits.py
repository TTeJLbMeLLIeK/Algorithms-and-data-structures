# https://acmp.ru/index.asp?main=task&id_task=33
with open("INPUT.TXT", "r") as input_file:
    harry_shots, larry_shots = map(int, input_file.read().split())

total_cans = harry_shots + larry_shots - 1

harry_missed = total_cans - harry_shots

larry_missed = total_cans - larry_shots

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(f"{harry_missed} {larry_missed}")
