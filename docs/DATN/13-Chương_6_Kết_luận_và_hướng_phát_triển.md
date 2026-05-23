# CHƯƠNG 6. KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

## 6.1 Kết luận

Đồ án tốt nghiệp **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** đã hoàn thành toàn diện các mục tiêu nghiên cứu và kỹ thuật đề ra, mang lại một giải pháp giáo dục EdTech VR có tính thực tiễn cao:

### 6.1.1 Những kết quả đạt được
1. **Kiến trúc phần mềm tối ưu**: Thiết kế và triển khai thành công kiến trúc hướng sự kiện (Event-Driven) xoay quanh bộ trung chuyển tĩnh `GestureHub`, tách biệt hoàn toàn phần thu phát cử chỉ tay của XR Hands SDK và phần logic bài kiểm tra của QuizManager, nâng cao tính mở rộng và ngăn ngừa Race Condition triệt để.
2. **Nhận dạng quỹ đạo vẽ nét đột phá**: Triển khai thành công module `VRMagicTrajectory` chiếu tọa độ 3D bàn tay lên không gian 2D cục bộ của Camera người chơi, phối hợp thuật toán toán học $1 Unistroke để nhận dạng thành công các ký hiệu động nét vẽ dài J và Z với độ chính xác cao (**87.3%**).
3. **Cơ chế Gamification sư phạm độc đáo**: Phát triển thành công các cơ chế giảm áp lực phòng thi tinh tế gồm **Hidden Mistakes** và **Invincibility Window**, giúp người học duy trì trạng thái tập trung sâu (Flow state) và không bị ức chế bởi các hạn chế vật lý của cảm biến kính VR.
4. **Hiệu năng và độ trễ vượt trội**: Tối ưu hóa đồ họa trên thiết bị Meta Quest 2 standalone đạt mức khung hình ổn định vượt mong đợi (**80 - 90 FPS**) và độ trễ nhận diện cực thấp (**< 0.2s**), triệt tiêu hoàn toàn hiện tượng chóng mặt (motion sickness) cho người học.
5. **Tính đóng góp và khả năng tái sử dụng**: Đóng gói thành công 3 module lập trình cốt lõi độc lập có khả năng tái sử dụng tức thì cho cộng đồng phát triển game giáo dục VR tương lai.

### 6.1.2 Những mặt hạn chế
* **Giới hạn phần cứng theo dõi tay**: Camera hồng ngoại trên kính Meta Quest 2 đôi khi bị mất dấu khớp xương tay (hand tracking occlusion) khi người chơi đưa tay quá sát mặt hoặc để tay khuất sau cổ tay kia.
* **Quy mô từ vựng giới hạn**: Hiện tại ứng dụng mới hỗ trợ nhận dạng các chữ cái đơn, chữ số cơ bản và các từ giao tiếp thông dụng ngắn. Chưa hỗ trợ phân tích cú pháp câu ngôn ngữ ký hiệu ASL dài hơi và phức tạp.

---

## 6.2 Hướng phát triển

Từ những kết quả đạt được và khắc phục các mặt hạn chế, đồ án đề xuất các hướng nghiên cứu phát triển tiếp theo trong tương lai:
1. **Nâng cấp công nghệ theo dõi tay**: Chuyển đổi và thử nghiệm ứng dụng trên kính **Meta Quest 3** tích hợp công nghệ theo dõi tay thế hệ mới kèm tính năng **Inside-Out Upper Body Tracking** để bắt dấu chuyển động cả thân trên và biểu cảm khuôn mặt (facial expressions), nâng cao độ chính xác nhận diện.
2. **Tích hợp Trí tuệ Nhân tạo tạo sinh (Conversational AI)**: 
   * Tích hợp mô hình ngôn ngữ lớn (LLM) và giọng nói nhân tạo thời gian thực vào NPC Kyle.
   * Biến Kyle thành một trợ lý ảo thực sự có khả năng đàm thoại tự do, giải thích ngữ cảnh sử dụng từ vựng ký hiệu ASL và trực tiếp chấm điểm hội thoại với người học.
3. **Ứng dụng cho Ngôn ngữ ký hiệu Việt Nam (VSL - Vietnamese Sign Language)**:
   * Chuyển đổi cơ sở dữ liệu cử chỉ tay ScriptableObject để nhận diện bảng chữ cái và từ vựng của ngôn ngữ ký hiệu Việt Nam.
   * Phát triển sản phẩm EdTech VR phục vụ trực tiếp cho các trường học giáo dục đặc biệt dành cho trẻ khiếm thính tại Việt Nam, đóng góp thiết thực cho cộng đồng xã hội nước nhà.
