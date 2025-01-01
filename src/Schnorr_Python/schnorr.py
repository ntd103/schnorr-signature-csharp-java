import random
import hashlib

# -----------------------------
# Các hàm toán học tự cài đặt
# -----------------------------

# Extended Euclidean Algorithm
# Trả về bộ (g, x, y) với g = gcd(a, b) và x, y thỏa a*x + b*y = g
def ext_gcd(a, b):
    if b == 0:
        return (a, 1, 0)
    g, x1, y1 = ext_gcd(b, a % b)
    x = y1
    y = x1 - (a // b) * y1
    return (g, x, y)

# Tính gcd bằng hàm ext_gcd (lấy g trong bộ (g, x, y))
def custom_gcd(a, b):
    return ext_gcd(a, b)[0]

# Tính lũy thừa (base^exp) mod m bằng phương pháp bình phương và nhân
def mod_exp(base, exp, m):
    result = 1
    base = base % m
    while exp > 0:
        if exp & 1:
            result = (result * base) % m
        base = (base * base) % m
        exp >>= 1
    return result

# -----------------------------
# Thuật toán Miller-Rabin
# -----------------------------
def miller_rabin_test(n, k=5):
    if n < 2:
        return False
    # Các trường hợp nhỏ
    small_primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29]
    if n in small_primes:
        return True
    for sp in small_primes:
        if n % sp == 0 and n != sp:
            return False

    # Tách n-1 = d * 2^r
    r, d = 0, n - 1
    while d % 2 == 0:
        d //= 2
        r += 1

    # Kiểm tra k lần
    for _ in range(k):
        a = random.randrange(2, n - 1)
        x = mod_exp(a, d, n)
        if x == 1 or x == n - 1:
            continue
        for __ in range(r - 1):
            # x = (x*x) % n --> có thể dùng mod_exp(x, 2, n), nhưng phép nhân trực tiếp cũng được
            x = (x * x) % n
            if x == n - 1:
                break
        else:
            return False
    return True

# -----------------------------
# Sinh p, q sao cho q | (p - 1)
# -----------------------------
def generate_large_prime_numbers():
    while True:
        q_candidate = random.randrange(2**10, 2**11)  # Ví dụ q ~ 10-11 bit
        if miller_rabin_test(q_candidate):
            # p = q * k + 1
            p_candidate = q_candidate * random.randint(2, 100) + 1
            while not miller_rabin_test(p_candidate):
                p_candidate += q_candidate
            return p_candidate, q_candidate

# -----------------------------
# Sinh số ngẫu nhiên trong Z_p*
# -----------------------------
def random_number_in_Zp_star(p):
    while True:
        r = random.randrange(1, p)
        if custom_gcd(r, p) == 1:
            return r

# -----------------------------
# Sinh số ngẫu nhiên trong Z_q
# -----------------------------
def random_number_in_Zq(q):
    return random.randrange(1, q)

# -----------------------------
# Sinh khóa Schnorr
# -----------------------------
def generate_keys():
    p, q = generate_large_prime_numbers()
    b = random_number_in_Zp_star(p)
    # g = b^((p - 1)/q) mod p
    g = mod_exp(b, (p - 1)//q, p)
    while g == 1:
        b = random_number_in_Zp_star(p)
        g = mod_exp(b, (p - 1)//q, p)
    a = random_number_in_Zq(q)
    # y = g^a mod p
    y = mod_exp(g, a, p)
    return (p, q, g, y, b), a

# -----------------------------
# Hàm băm H(m)
# -----------------------------
def hash_function(message):
    return int(hashlib.sha256(message.encode()).hexdigest(), 16)

# -----------------------------
# Sinh chữ ký Schnorr
# -----------------------------
def generate_signature(private_key, public_key, m):
    p, q, g, y, b = public_key
    a = private_key
    k = random_number_in_Zq(q)
    r = mod_exp(g, k, p)
    e = hash_function(m + str(r)) % q
    s = (a * e + k) % q
    return (s, e, k, r)

# -----------------------------
# Kiểm tra chữ ký Schnorr
# -----------------------------
def verify_signature(public_key, signature, m):
    p, q, g, y, b = public_key
    s, e, _, _ = signature
    # y^(-e) mod p --> mod_exp(y, q - e, p) (vì p là nguyên tố, y^(-e) ≡ y^(q-e) mod p)
    inv_y_e = mod_exp(y, q - e, p)
    v = (mod_exp(g, s, p) * inv_y_e) % p
    e_prime = hash_function(m + str(v)) % q
    return (e_prime == e, v, e_prime)

# -----------------------------
# Chức năng chính
# -----------------------------
if __name__ == "__main__":
    choice = input("Nhập (y) để sinh khóa ngẫu nhiên, (n) để nhập thủ công: ").lower()
    if choice == 'y':
        public_key, private_key = generate_keys()
    else:
        p = int(input("Nhập p: "))
        q = int(input("Nhập q: "))
        b = int(input("Nhập b: "))
        g = int(input("Nhập g: "))
        y = int(input("Nhập y (khóa công khai): "))
        private_key = int(input("Nhập private key (a): "))
        public_key = (p, q, g, y, b)

    print("\n[+] Khóa công khai (p, q, g, y, b):", public_key)
    print("[+] Khóa bí mật (a):", private_key)

    msg = input("\nNhập thông điệp cần ký: ")

    # Tạo chữ ký
    s, e, k, r = generate_signature(private_key, public_key, msg)

    # Hiển thị các tham số
    print("\n[+] Thông điệp:", msg)
    print("[+] p:", public_key[0])
    print("[+] q:", public_key[1])
    print("[+] b:", public_key[4])
    print("[+] g:", public_key[2], "   # b^((p - 1)/q) mod p")
    print("[+] a (khóa bí mật):", private_key)
    print("[+] y:", public_key[3], "   # g^a mod p")
    print("[+] k (ngẫu nhiên):", k)
    print("[+] r:", r, "   # g^k mod p")
    print("[+] e:", e, "   # H(m || r) mod q")
    print("[+] s:", s, "   # (a*e + k) mod q")

    # Kiểm tra chữ ký
    valid, v, e_prime = verify_signature(public_key, (s, e, k, r), msg)
    print("\n[+] v =", v, "  # (g^s * y^(-e)) mod p")
    print("[+] e' =", e_prime, " # H(m || v) mod q")

    if valid:
        print("Chữ ký hợp lệ.")
    else:
        print("Chữ ký không hợp lệ.")