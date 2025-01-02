package javaapplication6;

import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;

public class SchnorrSignature {
    private BigInteger p, q, g, y, r, s;
    private KeyPair keyPair;
    private final SecureRandom random = new SecureRandom();

    public SchnorrSignature(BigInteger p, BigInteger q, BigInteger g, KeyPair keyPair) {
        this.p = p;
        this.q = q;
        this.g = g;
        this.keyPair = keyPair;
        this.y = keyPair.getPublicKey(); // Khóa công khai người ký
    }

    public String signMessage(String message) {
        try {
            // Tạo số ngẫu nhiên k từ nhóm [1, q-1]
            BigInteger k;
            do {
                k = new BigInteger(q.bitLength(), random).mod(q.subtract(BigInteger.ONE)).add(BigInteger.ONE);
            } while (k.equals(BigInteger.ZERO)); // Đảm bảo k không bằng 0

            // Tính giá trị r = g^k mod p
            r = g.modPow(k, p);

            // Băm thông điệp
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            byte[] hashBytes = digest.digest(message.getBytes());
            BigInteger hash = new BigInteger(1, hashBytes);

            // Tính giá trị s = (k - x * hash) mod q
            s = (k.subtract(keyPair.getPrivateKey().multiply(hash)).mod(q)).mod(q);

            // Trả về chữ ký dưới dạng r và s
            return "r = " + r + ", s = " + s;
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return "Lỗi: Không tìm thấy thuật toán băm";
        }
    }

    public boolean verifySignature(String message, String signature) {
        try {
            // Tách giá trị r và s từ chữ ký
            String[] parts = signature.replace("r = ", "").replace("s = ", "").split(", ");
            if (parts.length != 2) {
                return false; // Đảm bảo chữ ký có đúng 2 phần
            }

            BigInteger r = new BigInteger(parts[0]);
            BigInteger s = new BigInteger(parts[1]);

            // Băm lại thông điệp
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            byte[] hashBytes = digest.digest(message.getBytes());
            BigInteger hash = new BigInteger(1, hashBytes);

            // In thông tin về hàm hash
            System.out.println("Thông điệp ban đầu: " + message);
            System.out.println("Mảng băm của thông điệp (SHA-256): " + bytesToHex(hashBytes));
            System.out.println("Giá trị hash (BigInteger): " + hash);

            // Kiểm tra điều kiện hợp lệ của r và s
            if (r.compareTo(BigInteger.ZERO) <= 0 || r.compareTo(p) >= 0) {
                return false; // r phải nằm trong phạm vi [0, p-1]
            }
            if (s.compareTo(BigInteger.ZERO) < 0 || s.compareTo(q) >= 0) {
                return false; // s phải nằm trong phạm vi [0, q-1]
            }

            // Tính lại giá trị v trong quá trình xác minh
            BigInteger v = g.modPow(s, p).multiply(y.modPow(hash, p)).mod(p);
            System.out.println("Giá trị v trong xác minh: " + v);
            System.out.println("Giá trị r trong xác minh: " + r);
            // Kiểm tra xem v có bằng r không
            return v.equals(r);
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return false;
        } catch (Exception e) {
            return false;
        }
    }


    // Chuyển đổi byte[] thành chuỗi hex để hiển thị
    private String bytesToHex(byte[] bytes) {
        StringBuilder hexString = new StringBuilder();
        for (byte b : bytes) {
            hexString.append(String.format("%02x", b));
        }
        return hexString.toString();
    }
}
