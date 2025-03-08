# https://acmp.ru/index.asp?main=task&id_task=766
with open("INPUT.TXT", "r") as input_file:
    N, M, K = map(int, input_file.read().split())

total_nuts = N * M

if total_nuts >= K:
    result = "YES"
else:
    result = "NO"

with open("OUTPUT.TXT", "w") as output_file:
    output_file.write(result)
