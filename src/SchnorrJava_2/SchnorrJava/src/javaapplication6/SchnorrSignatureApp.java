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
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;
import java.util.ArrayList;
import java.util.List;
import java.io.*;
import javax.swing.filechooser.FileNameExtensionFilter;


public class SchnorrSignatureApp {
    private static BigInteger p, q, g, x, y; // Lưu trữ p, q, g, x, y
    private static KeyPair keyPair;
    private static JTextField txtP;
    private static JTextField txtQ;
    private static JTextField txtG;
    private static JTextField txtX;
    private static JTextField txtY;
    private static String lastR; // Biến để lưu trữ giá trị r
    private static String lastS; // Biến để lưu trữ giá trị s
    private static JTextField txtB; // Biến để lưu trữ ô nhập b

    public static void main(String[] args) {
        SwingUtilities.invokeLater(SchnorrSignatureApp::createAndShowGUI);
    }

    private static void createAndShowGUI() {
        JFrame frame = new JFrame("Chương trình chữ ký Schnorr");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(900, 700);

        // Font size settings
        Font labelFont = new Font("Arial", Font.BOLD, 16);
        Font textFieldFont = new Font("Arial", Font.PLAIN, 14);

        // Main panel với GridLayout
        JPanel mainPanel = new JPanel(new GridBagLayout()); // Sử dụng GridBagLayout thay vì GridLayout

        // Bọc mainPanel trong một JPanel khác để thêm padding
        JPanel wrapperPanel = new JPanel(new BorderLayout());
        wrapperPanel.setBorder(BorderFactory.createEmptyBorder(40, 20, 40, 20)); // Padding: trên, trái, dưới, phải
        wrapperPanel.add(mainPanel, BorderLayout.CENTER);

        // Panel cho phần tạo khóa
        JPanel keyGenerationPanel = new JPanel(new GridBagLayout());
        keyGenerationPanel.setBorder(BorderFactory.createTitledBorder("Tạo khóa"));
        
        JLabel lblP = new JLabel("Nhập p (số nguyên tố):");
        lblP.setFont(labelFont);
        txtP = new JTextField();
        txtP.setPreferredSize(new Dimension(250, 60));
        txtP.setFont(textFieldFont);

        JLabel lblQ = new JLabel("Nhập q (ước của p-1):");
        lblQ.setFont(labelFont);
        txtQ = new JTextField();
        txtQ.setPreferredSize(new Dimension(250, 60));
        txtQ.setFont(textFieldFont);

        JLabel lblB = new JLabel("Nhập b:");
        lblB.setFont(labelFont);
        txtB = new JTextField();
        txtB.setPreferredSize(new Dimension(250, 60));
        txtB.setFont(textFieldFont);

        JLabel lblX = new JLabel("Nhập khóa bí mật x:");
        lblX.setFont(labelFont);
        txtX = new JTextField();
        txtX.setPreferredSize(new Dimension(250, 60));
        txtX.setFont(textFieldFont);

        // Thêm các thành phần vào panel tạo khóa
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(10, 10, 10, 10); // Khoảng cách giữa các thành phần
        gbc.fill = GridBagConstraints.HORIZONTAL;

        // Các thành phần trong keyGenerationPanel
        gbc.gridx = 0;
        gbc.gridy = 0;
        keyGenerationPanel.add(lblP, gbc);
        gbc.gridx = 1;
        keyGenerationPanel.add(txtP, gbc);

        gbc.gridx = 0;
        gbc.gridy = 1;
        keyGenerationPanel.add(lblQ, gbc);
        gbc.gridx = 1;
        keyGenerationPanel.add(txtQ, gbc);

        // Thêm ô nhập cho b
        gbc.gridx = 0;
        gbc.gridy = 2;
        keyGenerationPanel.add(lblB, gbc);
        gbc.gridx = 1;
        keyGenerationPanel.add(txtB, gbc);

        // Thêm ô nhập cho khóa bí mật x
        gbc.gridx = 0;
        gbc.gridy = 3;
        keyGenerationPanel.add(lblX, gbc);
        gbc.gridx = 1;
        keyGenerationPanel.add(txtX, gbc);

        // Thêm nút "Tạo khoá từ p, q, g"
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.gridwidth = 2; // Chiếm cả hai cột
        JButton btnCreateKeys = new JButton("Tạo khoá");
        keyGenerationPanel.add(btnCreateKeys, gbc);

        // Thêm nút "Sinh khoá tự động"
        gbc.gridy = 5; // Dòng tiếp theo
        JButton btnGenerateKeys = new JButton("Sinh khoá tự động");
        keyGenerationPanel.add(btnGenerateKeys, gbc);

        // Thêm ô nhập cho g
        gbc.gridx = 0;
        gbc.gridy = 6;
        JLabel lblG = new JLabel("g:");
        lblG.setFont(labelFont);
        keyGenerationPanel.add(lblG, gbc);
        gbc.gridx = 1;
        txtG = new JTextField();
        txtG.setPreferredSize(new Dimension(250, 60));
        txtG.setFont(textFieldFont);
        txtG.setEditable(false);
        keyGenerationPanel.add(txtG, gbc);

        // Thêm ô nhập cho khóa công khai y
        gbc.gridx = 0;
        gbc.gridy = 7;
        JLabel lblY = new JLabel("Khóa công khai (y):");
        lblY.setFont(labelFont);
        keyGenerationPanel.add(lblY, gbc);
        gbc.gridx = 1;
        txtY = new JTextField();
        txtY.setEditable(false);
        txtY.setPreferredSize(new Dimension(250, 60));
        txtY.setFont(textFieldFont);
        keyGenerationPanel.add(txtY, gbc);

        // Panel cho phần nhập chữ ký
        JPanel signaturePanel = new JPanel(new GridBagLayout());
        signaturePanel.setBorder(BorderFactory.createTitledBorder("Nhập chữ ký"));

        JLabel lblMessage = new JLabel("Nhập thông điệp:");
        lblMessage.setFont(labelFont);
        JTextField txtMessage = new JTextField();
        txtMessage.setPreferredSize(new Dimension(250, 60));
        txtMessage.setFont(textFieldFont);

        JLabel lblSignatureInput = new JLabel("Chữ ký (r, s):");
        lblSignatureInput.setFont(labelFont);
        JTextField txtSignature = new JTextField();
        txtSignature.setEditable(false);
        txtSignature.setPreferredSize(new Dimension(250, 60));
        txtSignature.setFont(textFieldFont);

        JButton btnSign = new JButton("Ký thông điệp");
        btnSign.setPreferredSize(new Dimension(200, 50));
        btnSign.setFont(new Font("Arial", Font.BOLD, 14));

        // Sử dụng l���i biến gbc đã định nghĩa trước đó
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.anchor = GridBagConstraints.WEST; // Căn trái
        gbc.insets = new Insets(10, 10, 10, 10); // Thêm khoảng cách giữa các thành phần

        // Thêm lblMessage và txtMessage vào hàng 0, cột 0 và 1
        gbc.gridx = 0;
        gbc.gridy = 0;
        signaturePanel.add(lblMessage, gbc);
        gbc.gridx = 0;
        gbc.gridy = 1; // Đảm bảo hàng vẫn là 0
        signaturePanel.add(txtMessage, gbc);

        // Thêm lblSignatureInput và txtSignature vào hàng 1, cột 0 và 1
        gbc.gridx = 0;
        gbc.gridy = 2;
        signaturePanel.add(lblSignatureInput, gbc);
        gbc.gridx = 0;
        gbc.gridy = 3;
        signaturePanel.add(txtSignature, gbc);

        // Thêm btnSign vào hàng 2, chiếm cả hai cột
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.gridwidth = 2; // Chiếm cả hai cột
        signaturePanel.add(btnSign, gbc);

        // Thêm nút mở tệp cho panel tạo chữ ký
        addFileChooserButton(signaturePanel, txtMessage);

        // Thêm nút "Lưu chữ ký" vào panel chữ ký
        JButton btnSaveSignature = new JButton("Lưu chữ ký");
        gbc.gridx = 0;
        gbc.gridy = 5; // Dòng tiếp theo
        gbc.gridwidth = 2; // Chiếm cả hai cột
        signaturePanel.add(btnSaveSignature, gbc);

        // Thêm hành động cho nút "Lưu chữ ký"
        btnSaveSignature.addActionListener(e -> saveSignatureToFile(txtSignature.getText()));

        // Panel cho phần xác minh chữ ký
        JPanel verificationPanel = new JPanel(new GridBagLayout());
        verificationPanel.setBorder(BorderFactory.createTitledBorder("Xác minh chữ ký"));

        // Thêm ô nhập thông điệp
        JLabel lblMessageVerification = new JLabel("Nhập thông điệp:");
        lblMessageVerification.setFont(labelFont);
        JTextField txtMessageVerification = new JTextField();
        txtMessageVerification.setPreferredSize(new Dimension(250, 60));
        txtMessageVerification.setFont(textFieldFont);

        JLabel lblSignatureVerification = new JLabel("Chữ ký (r, s):");
        lblSignatureVerification.setFont(labelFont);
        JTextField txtSignatureVerification = new JTextField();
        txtSignatureVerification.setPreferredSize(new Dimension(250, 60));
        txtSignatureVerification.setFont(textFieldFont);

        JLabel lblPVerification = new JLabel("Nhập p:");
        lblPVerification.setFont(labelFont);
        JTextField txtPVerification = new JTextField();
        txtPVerification.setPreferredSize(new Dimension(250, 60));
        txtPVerification.setFont(textFieldFont);

        JLabel lblQVerification = new JLabel("Nhập q:");
        lblQVerification.setFont(labelFont);
        JTextField txtQVerification = new JTextField();
        txtQVerification.setPreferredSize(new Dimension(250, 60));
        txtQVerification.setFont(textFieldFont);

        JLabel lblGVerification = new JLabel("Nhập g:");
        lblGVerification.setFont(labelFont);
        JTextField txtGVerification = new JTextField();
        txtGVerification.setPreferredSize(new Dimension(250, 60));
        txtGVerification.setFont(textFieldFont);

        JLabel lblYVerification = new JLabel("Nhập y:");
        lblYVerification.setFont(labelFont);
        JTextField txtYVerification = new JTextField();
        txtYVerification.setPreferredSize(new Dimension(250, 60));
        txtYVerification.setFont(textFieldFont);

        JButton btnVerifySignature = new JButton("Xác minh chữ ký");
        btnVerifySignature.setPreferredSize(new Dimension(200, 50));
        btnVerifySignature.setFont(new Font("Arial", Font.BOLD, 14));

        JTextField txtVerificationResult = new JTextField();
        txtVerificationResult.setEditable(false);
        txtVerificationResult.setPreferredSize(new Dimension(300, 60));
        txtVerificationResult.setFont(textFieldFont);

        // Thêm các thành phần vào panel xác minh chữ ký
        GridBagConstraints gbcVerification = new GridBagConstraints();
        gbcVerification.insets = new Insets(10, 10, 10, 10); // Khoảng cách giữa các thành phần
        gbcVerification.fill = GridBagConstraints.HORIZONTAL;

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 0;
        verificationPanel.add(lblMessageVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtMessageVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 1;
        verificationPanel.add(lblSignatureVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtSignatureVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 2;
        verificationPanel.add(lblPVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtPVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 3;
        verificationPanel.add(lblQVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtQVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 4;
        verificationPanel.add(lblGVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtGVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 5;
        verificationPanel.add(lblYVerification, gbcVerification);
        gbcVerification.gridx = 1;
        verificationPanel.add(txtYVerification, gbcVerification);

        gbcVerification.gridx = 0;
        gbcVerification.gridy = 6;
        gbcVerification.gridwidth = 2; // Chiếm cả hai cột
        verificationPanel.add(btnVerifySignature, gbcVerification);

        gbcVerification.gridy = 7;
        verificationPanel.add(txtVerificationResult, gbcVerification);

        // Thêm nút mở tệp cho panel xác minh chữ ký
        addFileChooserButton(verificationPanel, txtMessageVerification);

       

        // Thêm các panel vào mainPanel
        GridBagConstraints gbcMain = new GridBagConstraints();
        gbcMain.fill = GridBagConstraints.BOTH; // Cho phép phóng to thu nhỏ
        gbcMain.weightx = 1.0; // Tỉ lệ chiều rộng
        gbcMain.weighty = 1.0; // Tỉ lệ chiều cao

        gbcMain.gridx = 0;
        gbcMain.gridy = 0;
        mainPanel.add(keyGenerationPanel, gbcMain); // Thêm keyGenerationPanel vào mainPanel

        gbcMain.gridx = 1; // Cột tiếp theo
        mainPanel.add(signaturePanel, gbcMain); // Thêm signaturePanel vào mainPanel

        // Thêm panel xác minh chữ ký vào mainPanel
        gbcMain.gridx = 2; // Cột tiếp theo cho panel xác minh
        mainPanel.add(verificationPanel, gbcMain);

        // Add wrapperPanel to frame
        frame.add(wrapperPanel);
        frame.setVisible(true);

        // Button actions
        btnGenerateKeys.addActionListener(e -> generateKeysAutomatically());

        btnCreateKeys.addActionListener(e -> {
            try {
                // Lấy giá trị từ ô nhập
                p = new BigInteger(txtP.getText().trim());
                q = new BigInteger(txtQ.getText().trim());
                BigInteger b = new BigInteger(txtB.getText().trim());
                x = new BigInteger(txtX.getText().trim());

                // Kiểm tra p là số nguyên tố
                if (!p.isProbablePrime(100)) {
                    JOptionPane.showMessageDialog(frame, "p phải là số nguyên tố.", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                // Kiểm tra q là số nguyên tố và là ước của p-1
                if (!q.isProbablePrime(100) || p.subtract(BigInteger.ONE).mod(q).compareTo(BigInteger.ZERO) != 0) {
                    JOptionPane.showMessageDialog(frame, "q phải là số nguyên tố và là ước của p-1.", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                // Kiểm tra b là số nguyên tố cùng nhau với p
                if (b.gcd(p).compareTo(BigInteger.ONE) != 0) {
                    JOptionPane.showMessageDialog(frame, "b phải là số nguyên tố cùng nhau với p.", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                // Kiểm tra x không lớn hơn q
                if (x.compareTo(q) >= 0) {
                    JOptionPane.showMessageDialog(frame, "x không thể lớn hơn q.", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                // Tính giá trị g = b^(p-1)/q mod p
                BigInteger exponent = p.subtract(BigInteger.ONE).divide(q); // Tính (p-1)/q
                g = b.modPow(exponent, p); // Tính b^(p-1)/q mod p

                // Tính giá trị y = g^x mod p
                y = g.modPow(x, p); // Tính y

                // Cập nhật ô nhập g và y với giá trị đã tính
                txtG.setText(g.toString());
                txtY.setText(y.toString());

                // Tạo keyPair
                keyPair = new KeyPair(x, y);

            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(frame, "Vui lòng nhập đúng định dạng số.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });

        btnSign.addActionListener(e -> {
            String message = txtMessage.getText().trim();
            if (!message.isEmpty() && keyPair != null) {
                SchnorrSignature schnorrSignature = new SchnorrSignature(p, q, g, keyPair);
                String signature = schnorrSignature.signMessage(message);
                txtSignature.setText(signature);

                // Tách r và s từ chữ ký và lưu trữ
                String[] signatureParts = signature.split(", ");
                if (signatureParts.length == 2) {
                    lastR = signatureParts[0].trim();
                    lastS = signatureParts[1].trim();
                }
            } else {
                JOptionPane.showMessageDialog(frame, "Tạo khoá và nhập message trước", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });

        // Button actions for verification
        btnVerifySignature.addActionListener(e -> {
            String message = txtMessageVerification.getText().trim();
            String signature = txtSignatureVerification.getText().trim();
            String pInput = txtPVerification.getText().trim();
            String qInput = txtQVerification.getText().trim();
            String gInput = txtGVerification.getText().trim();
            String yInput = txtYVerification.getText().trim();

            // Tách r và s từ chữ ký
            String[] signatureParts = signature.split(", ");
            if (signatureParts.length != 2) {
                JOptionPane.showMessageDialog(frame, "Chữ ký không hợp lệ.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            String rInput = signatureParts[0].trim();
            String sInput = signatureParts[1].trim();

            if (!rInput.equals(lastR) || !sInput.equals(lastS)) {
                JOptionPane.showMessageDialog(frame, "Giá trị chữ ký không khớp.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            if (!pInput.equals(p.toString())) {
                JOptionPane.showMessageDialog(frame, "Giá trị p không khớp với khóa đã tạo.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            if (!qInput.equals(q.toString())) {
                JOptionPane.showMessageDialog(frame, "Giá trị q không khớp với khóa đã tạo.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            if (!gInput.equals(g.toString())) {
                JOptionPane.showMessageDialog(frame, "Giá trị g không khớp với khóa đã tạo.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            if (!yInput.equals(keyPair.getPublicKey().toString())) {
                JOptionPane.showMessageDialog(frame, "Giá trị y không khớp với khóa đã tạo.", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }

            if (!message.isEmpty() && !signature.isEmpty()) {
                SchnorrSignature schnorrSignature = new SchnorrSignature(p, q, g, keyPair);
                boolean isValid = schnorrSignature.verifySignature(message, signature);
                txtVerificationResult.setText(isValid ? "Chữ ký hợp lệ" : "Chữ ký không hợp lệ");
            } else {
                JOptionPane.showMessageDialog(frame, "Nhập message và sinh khoá trước.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });
    }

    private static void generateKeysAutomatically() {
        // Generate prime number q in the range of 2^32
        q = BigInteger.probablePrime(256, new SecureRandom());
        
        // Calculate p = 2q + 1
        p = q.multiply(BigInteger.TWO).add(BigInteger.ONE);
        
        // Ensure p is prime
        while (!p.isProbablePrime(100)) {
            q = BigInteger.probablePrime(256, new SecureRandom());
            p = q.multiply(BigInteger.TWO).add(BigInteger.ONE);
        }

        // Generate private key x
        do {
            x = new BigInteger(q.bitLength(), new SecureRandom()).mod(q.subtract(BigInteger.ONE)).add(BigInteger.ONE); // x nằm trong [1, q-1]
        } while (x.compareTo(q) >= 0); // Đảm bảo x không lớn hơn q

        // Generate b in the range [2, p-1] and ensure b is coprime with p
        BigInteger b;
        do {
            b = new BigInteger(p.bitLength(), new SecureRandom()).mod(p.subtract(BigInteger.TWO)).add(BigInteger.TWO); // b nằm trong [2, p-1]
        } while (b.gcd(p).compareTo(BigInteger.ONE) != 0); // Kiểm tra b là số nguyên tố cùng nhau với p

        // Tính giá trị g = b^(p-1)/q mod p
        BigInteger exponent = p.subtract(BigInteger.ONE).divide(q); // Tính (p-1)/q
        g = b.modPow(exponent, p); // Tính b^(p-1)/q mod p

        txtP.setText(p.toString());
        txtQ.setText(q.toString());
        txtB.setText(b.toString());
        txtX.setText(x.toString());

        // Hiển thị thông báo
        JOptionPane.showMessageDialog(null, "Tạo khoá thành công:\n" +
                "Khoá bí mật (x): " + x + "\n" +
                "p = " + p + ", q = " + q + ", b = " + b,
                "Sinh khoá", JOptionPane.INFORMATION_MESSAGE);
    }


    private static void addFileChooserButton(JPanel panel, JTextField textField) {
        JButton btnOpenFile = new JButton("Mở tệp");
        btnOpenFile.addActionListener(e -> {
            JFileChooser fileChooser = new JFileChooser();
            FileNameExtensionFilter filter = new FileNameExtensionFilter("Text Files", "txt");
            fileChooser.setFileFilter(filter);
            int returnValue = fileChooser.showOpenDialog(null);
            if (returnValue == JFileChooser.APPROVE_OPTION) {
                File selectedFile = fileChooser.getSelectedFile();
                String content = readFileContent(selectedFile);
                textField.setText(content);
            }
        });
        panel.add(btnOpenFile);
    }

    private static String readFileContent(File file) {
        StringBuilder content = new StringBuilder();
        try {
            if (file.getName().endsWith(".txt")) {
                BufferedReader br = new BufferedReader(new FileReader(file));
                String line;
                while ((line = br.readLine()) != null) {
                    content.append(line).append("\n");
                }
                br.close();
            } else {
                JOptionPane.showMessageDialog(null, "Vui lòng chọn tệp .txt.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        } catch (IOException e) {
            JOptionPane.showMessageDialog(null, "Lỗi khi đọc file: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
        return content.toString().trim();
    }

    // Phương thức để lưu chữ ký vào tệp
    private static void saveSignatureToFile(String signature) {
        if (signature.isEmpty()) {
            JOptionPane.showMessageDialog(null, "Chữ ký trống. Vui lòng ký trước.", "Error", JOptionPane.ERROR_MESSAGE);
            return;
        }

        JFileChooser fileChooser = new JFileChooser();
        fileChooser.setDialogTitle("Lưu chữ ký");
        int userSelection = fileChooser.showSaveDialog(null);

        if (userSelection == JFileChooser.APPROVE_OPTION) {
            File fileToSave = fileChooser.getSelectedFile();
            try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileToSave))) {
                // Lưu chữ ký và các giá trị p, q, g, y
                writer.write("Chữ ký: " + signature + "\n");
                writer.write("p: " + p + "\n");
                writer.write("q: " + q + "\n");
                writer.write("g: " + g + "\n");
                writer.write("y: " + y + "\n");
                JOptionPane.showMessageDialog(null, "Chữ ký đã được lưu thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (IOException e) {
                JOptionPane.showMessageDialog(null, "Lỗi khi lưu chữ ký: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            }
        }
    }

}