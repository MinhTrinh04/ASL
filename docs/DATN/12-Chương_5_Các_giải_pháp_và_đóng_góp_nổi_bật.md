# CHƯƠNG 5. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT

Đồ án tốt nghiệp **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** không chỉ dừng lại ở việc lắp ghép các bộ công cụ có sẵn, mà đã nghiên cứu, thử nghiệm và đóng góp 3 giải pháp công nghệ - sư phạm nổi bật cho lĩnh vực công nghệ giáo dục EdTech VR.

---

## 5.1 Giải pháp chiếu nét vẽ 2D cục bộ trong không gian thực tế ảo phục vụ nhận dạng cử chỉ chữ viết động (J, Z)

### 5.1.1 Đặt vấn đề
Trong ngôn ngữ ký hiệu ASL, các chữ cái **`J`** và **`Z`** bắt buộc phải sử dụng chuyển động vẽ nét tay (ngón trỏ di chuyển vẽ hình cái móc hoặc hình chữ Z trong không gian). Nhận diện các chữ cái này bằng công nghệ so khớp tư thế ngón tay tĩnh (Static Hand Shape) của XR Hands hoàn toàn thất bại vì:
* Hình dạng các ngón tay liên tục thay đổi trong suốt quá trình vẽ nét.
* Cảm biến camera hồng ngoại của kính VR dễ bị mất dấu khớp xương ngón tay khi tay di chuyển nhanh ngoài vùng bắt tiêu chuẩn.
* Người học có thể đứng ở bất kỳ vị trí và hướng nhìn nào trong phòng học ảo, dẫn đến tọa độ nét vẽ 3D trong không gian thế giới (World Space Coordinates) của mỗi lần vẽ hoàn toàn khác xa nhau, không thể dùng làm dữ liệu so khớp mẫu.

### 5.1.2 Giải pháp đề xuất
Đồ án đề xuất giải pháp kỹ thuật đột phá thông qua bộ nhận dạng nét vẽ **`VRMagicTrajectory`** kết hợp chiếu tọa độ cục bộ (Local Space Projection):
1. **Lấy ngón trỏ làm bút vẽ**: Sử dụng đầu ngón trỏ `XRHandJointID.IndexTip` làm điểm bắt tọa độ. Hệ thống chỉ ghi nhận điểm khi người học giữ tay ở một tư thế nền nhất định (`baseHandShape`).
2. **Chiếu tọa độ song song 2D cục bộ**: Thay vì lấy tọa độ thế giới 3D, hệ thống chiếu song song các tọa độ này lên hệ trục tọa độ cục bộ của Camera người chơi (`playerCamera` đại diện cho góc nhìn HMD) bằng phương thức:
   ```csharp
   Vector3 localPoint = playerCamera.InverseTransformPoint(wp);
   ```
   Tọa độ `localPoint.x` và `localPoint.y` biểu diễn hoàn hảo quỹ đạo nét vẽ trên một mặt phẳng phẳng 2D giả tưởng luôn song song thẳng đứng ngay trước mắt người học, bất kể người học đang đứng ở đâu hay quay mặt về hướng nào trong phòng 3D.
3. **Chuẩn hóa nét vẽ đơn ($1 Unistroke)**: Chuỗi các điểm 2D cục bộ này được đưa vào bộ nhận diện $1 Unistroke để chuẩn hóa về kích thước và trọng tâm, sau đó so khớp bằng giải thuật tìm kiếm tỉ lệ vàng (Golden Section Search) với nét vẽ chữ mẫu J hoặc Z.

### 5.1.3 Kết quả đạt được
Giải pháp này giúp hệ thống đạt tỉ lệ nhận dạng chữ **`J`** và **`Z`** chính xác vượt trội (**87.3%**), giải quyết triệt để hạn chế kỹ thuật nhận diện cử chỉ động mà hầu hết các ứng dụng ASL VR hiện tại trên cửa hàng Meta Horizon Store bỏ qua.

---

## 5.2 Giải pháp giảm thiểu tải nhận thức và tăng cường động lực học tập thông qua cơ chế Gamification phòng thi tinh tế

### 5.2.1 Đặt vấn đề
Trong quá trình làm bài thi kiểm tra (Exam Mode), việc cảm biến tay của kính VR đôi khi bắt lệch góc ngón tay hoặc bị che khuất trong một mili-giây (gọi là nhiễu cảm biến) dễ khiến hệ thống hiểu nhầm người học làm sai cử chỉ. Nếu hệ thống trừ điểm phạt trực tiếp ngay lập tức, người học sẽ bị rơi vào trạng thái ức chế tâm lý nặng nề, phá vỡ động lực học tập nhập vai.

### 5.2.2 Giải pháp đề xuất
Đồ án tích hợp cơ chế Gamification thông minh nhằm giảm thiểu tải nhận thức ngoại lai và bảo vệ tâm lý người chơi:
1. **Cơ chế Sai lầm ẩn (Hidden Mistakes)**: Người học làm sai cử chỉ không bị trừ điểm phạt ngay. Hệ thống cho phép gõ sai tối đa 3 lần (`hiddenMistakes++`) mới quy đổi thành 1 lỗi phạt chính thức (`currentQuestionMistakes++`). Trong lúc sai ẩn, hệ thống hoàn toàn im lặng, không đổi màu chữ đỏ để người học tự tin điều chỉnh ngón tay mà không bị phân tâm.
2. **Cơ chế Cửa sổ vô địch (Invincibility Window)**: Ngay sau khi người học mắc 1 lỗi phạt chính thức đầu tiên, hệ thống kích hoạt cửa sổ vô địch ẩn trong vòng `invincibilityDuration` (2.5s). Trong khoảng thời gian này, mọi cử chỉ tay gõ sai do người chơi đang cuống cuồng điều chỉnh tay đều được hệ thống bỏ qua và miễn phạt điểm.
3. **Cơ chế miễn phạt hoàn toàn cho chữ cái động (`noPenaltyGestures`)**: Hai chữ cái khó nhất là `J` và `Z` được xếp vào danh sách miễn phạt điểm. Người học có thể vẽ sai vô số lần tại câu hỏi này và thoải mái thử lại cho đến khi đúng mà không hề bị tính lỗi phạt.

### 5.2.3 Ý nghĩa EdTech
Về mặt EdTech, giải pháp này giúp duy trì trạng thái tập trung cao độ (**Flow state**) của người học. Người học không bị ức chế bởi các hạn chế vật lý của cảm biến kính VR, tạo ra trải nghiệm thi cử mang tính xây dựng và động lực học tập bền vững.

---

## 5.3 Các module có thể tái sử dụng trong EdTech VR

Để hỗ trợ cộng đồng phát triển game VR giáo dục tương tự trong tương lai, đồ án đã module hóa sâu sắc các lớp lập trình cốt lõi, biến chúng thành các khối xây dựng độc lập (Reusable Modules) có khả năng tái sử dụng tức thì:

### 5.3.1 Module GestureHub (Event Broker & Equivalence)
* **Chức năng**: Cung cấp bộ trung chuyển sự kiện cử chỉ tĩnh toàn cục độc lập. Đã lập trình sẵn cơ chế AreEquivalent gom nhóm cử chỉ tay tương đương cho các chữ cái dễ nhầm lẫn như `M`, `N`, `T`, `S`, `E`.
* **Khả năng tái sử dụng**: Nhà phát triển khác có thể import module này vào bất kỳ dự án Unity VR nào khác có sử dụng Hand Tracking để thu nhận sự kiện gõ phím cử chỉ mà không cần viết lại hệ thống sự kiện từ đầu.

### 5.3.2 Module TrajectoryRecognizer (Generic VR Drawing Engine)
* **Chức năng**: Module trọn gói gồm tệp `TrajectoryRecognizer.cs` và `UnistrokeRecognizer.cs` quản lý toàn bộ quy trình: Bắt đầu vẽ bám theo xương tay -> Hiển thị nét vẽ LineRenderer -> Chiếu tọa độ cục bộ Camera 2D -> Chuẩn hóa toán học và chạy so khớp $1 Unistroke.
* **Khả năng tái sử dụng**: Module có thể tái sử dụng để xây dựng các trò chơi VR vẽ phép thuật, vẽ ký hiệu mở cửa mật mã, vẽ hình học dạy toán học, hoặc nhận diện chữ số động bất kỳ bằng cách chỉ cần định nghĩa thêm tọa độ mẫu Template trong mã nguồn.

### 5.3.3 Module QuizManager (SO-based VR Quiz Engine)
* **Chức năng**: Bộ engine quản lý bài thi VR 3D cực kỳ linh hoạt. Điều phối toàn bộ luồng: Tải câu hỏi từ Scriptable Object, hiển thị hình ảnh/âm thanh phát âm, điền từ chỗ trống tự động (`AutoAdvanceGapFill`), và chạy 3 cơ chế giảm áp lực phòng thi (Hidden, Invincibility, No-penalty).
* **Khả năng tái sử dụng**: Nhà phát triển khác chỉ cần kéo prefab Quiz Board vào Scene mới, tạo các file dữ liệu câu hỏi `QuizData` (.asset) của riêng họ (ví dụ: thi học từ vựng tiếng Anh, thi toán học số học) nạp vào QuizManager là đã có ngay một hệ thống thi VR lập thể 3D chuyên nghiệp mà không cần sửa đổi một dòng code logic nào.
