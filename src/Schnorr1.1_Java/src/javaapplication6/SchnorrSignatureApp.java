/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package javaapplication6;

/**
 *
 * @author anthv
 */
import javax.swing.*;
import java.awt.*;
import java.math.BigInteger;
import java.security.SecureRandom;

public class SchnorrSignatureApp {
    private static BigInteger p, q, g;
    private static KeyPair keyPair;

    public static void main(String[] args) {
        SwingUtilities.invokeLater(SchnorrSignatureApp::createAndShowGUI);
    }

    private static void createAndShowGUI() {
        JFrame frame = new JFrame("Chương trình chữ ký schnorr");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(600, 400);

        // Main panel
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(6, 2, 10, 10));

        // Input fields and labels
        JLabel lblMessage = new JLabel("Nhập thông điệp:");
        JTextField txtMessage = new JTextField();

        JLabel lblSignature = new JLabel("Chữ ký (r, s):");
        JTextField txtSignature = new JTextField();
        txtSignature.setEditable(false);

        JLabel lblVerification = new JLabel("Kết quả:");
        JTextField txtVerification = new JTextField();
        txtVerification.setEditable(false);

        // Buttons
        JButton btnGenerateKeys = new JButton("Sinh khoá");
        JButton btnSign = new JButton("Ký thông điệp");
        JButton btnVerify = new JButton("Xác minh chữ ký");

        // Add components to panel
        panel.add(lblMessage);
        panel.add(txtMessage);
        panel.add(btnGenerateKeys);
        panel.add(new JLabel());
        panel.add(lblSignature);
        panel.add(txtSignature);
        panel.add(btnSign);
        panel.add(btnVerify);
        panel.add(lblVerification);
        panel.add(txtVerification);

        frame.add(panel);
        frame.setVisible(true);

        // Button actions
        btnGenerateKeys.addActionListener(e -> generateKeys());

        btnSign.addActionListener(e -> {
            String message = txtMessage.getText().trim();
            if (!message.isEmpty() && keyPair != null) {
                SchnorrSignature schnorrSignature = new SchnorrSignature(p, q, g, keyPair);
                String signature = schnorrSignature.signMessage(message);
                txtSignature.setText(signature);
            } else {
                JOptionPane.showMessageDialog(frame, "Tạo khoá và nhập message trước", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });

        btnVerify.addActionListener(e -> {
            String message = txtMessage.getText().trim();
            String signature = txtSignature.getText().trim();
            if (!message.isEmpty() && !signature.isEmpty()) {
                SchnorrSignature schnorrSignature = new SchnorrSignature(p, q, g, keyPair);
                boolean isValid = schnorrSignature.verifySignature(message, signature);
                txtVerification.setText(isValid ? "Valid Signature" : "Invalid Signature");
            } else {
                JOptionPane.showMessageDialog(frame, "Nhập message và sinh khoá trước.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });
    }

    private static void generateKeys() {
        // Generate prime numbers p and q, and generator g
        q = BigInteger.probablePrime(160, new SecureRandom());
        p = q.multiply(BigInteger.TWO).add(BigInteger.ONE); // p = 2q + 1
        while (!p.isProbablePrime(100)) {
            q = BigInteger.probablePrime(160, new SecureRandom());
            p = q.multiply(BigInteger.TWO).add(BigInteger.ONE);
        }
        g = BigInteger.TWO;
        while (g.modPow(q, p).compareTo(BigInteger.ONE) != 0) {
            g = g.add(BigInteger.ONE);
        }

        // Generate private key x and public key y
        BigInteger x = new BigInteger(q.bitLength() - 1, new SecureRandom());
        BigInteger y = g.modPow(x, p);
        keyPair = new KeyPair(x, y);

        JOptionPane.showMessageDialog(null, "Tạo khoá thành công:\n" +
                "Khoá công khai (y): " + y + "\n" +
                "Khoá bí mật(x): " + x + "\n" +
                "p = " + p + ", q = " + q + ", g = " + g,
                "Sinh khoá", JOptionPane.INFORMATION_MESSAGE);
    }
}