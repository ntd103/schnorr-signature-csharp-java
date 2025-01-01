
package javaapplication6;

import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;

public class SchnorrSignature {
    private BigInteger p, q, g;
    private KeyPair keyPair;
    private final SecureRandom random = new SecureRandom();

    public SchnorrSignature(BigInteger p, BigInteger q, BigInteger g, KeyPair keyPair) {
        this.p = p;
        this.q = q;
        this.g = g;
        this.keyPair = keyPair;
    }

    public String signMessage(String message) {
        try {
            BigInteger k = new BigInteger(q.bitLength() - 1, random).mod(q);
            BigInteger r = g.modPow(k, p);
            BigInteger hash = new BigInteger(1, MessageDigest.getInstance("SHA-256").digest(message.getBytes()));
            BigInteger s = (k.subtract(keyPair.getPrivateKey().multiply(hash)).mod(q)).mod(q);
            return "r = " + r + ", s = " + s;
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return "Lỗi";
        }
    }

    public boolean verifySignature(String message, String signature) {
        try {
            String[] parts = signature.replace("r = ", "").replace("s = ", "").split(", ");
            BigInteger r = new BigInteger(parts[0]);
            BigInteger s = new BigInteger(parts[1]);
            BigInteger hash = new BigInteger(1, MessageDigest.getInstance("SHA-256").digest(message.getBytes()));

            if (r.compareTo(BigInteger.ZERO) <= 0 || r.compareTo(p) >= 0) {
                return false;
            }
            if (s.compareTo(BigInteger.ZERO) < 0 || s.compareTo(q) >= 0) {
                return false;
            }

            BigInteger v = g.modPow(s, p).multiply(keyPair.getPublicKey().modPow(hash, p)).mod(p);
            return v.equals(r);
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return false;
        } catch (Exception e) {
            return false;
        }
    }
}