# CHƯƠNG 3. NỀN TẢNG LÝ THUYẾT VÀ CÔNG NGHỆ SỬ DỤNG

## 3.1 Các lý luận về phương pháp dạy học và nền tảng EdTech

Để xây dựng một ứng dụng công nghệ giáo dục (EdTech) thực sự hiệu quả và có cơ sở khoa học vững chắc, đồ án đã nghiên cứu và tích hợp ba lý thuyết giáo dục học cốt lõi vào thiết kế trải nghiệm người dùng trong môi trường thực tế ảo.

### 3.1.1 Nón trải nghiệm Edgar Dale (Edgar Dale's Cone of Experience)
Nón trải nghiệm Edgar Dale là một mô hình nổi tiếng mô tả mối liên hệ giữa các hình thức tiếp nhận thông tin và hiệu quả ghi nhớ của não bộ sau một khoảng thời gian. Mô hình này phân cấp từ các trải nghiệm thụ động nhất ở đỉnh nón (đọc chữ, nghe giảng) đến các trải nghiệm chủ động nhất ở đáy nón (thực hành thực tế, làm mô phỏng).

Theo nghiên cứu của Edgar Dale:
* Người học chỉ ghi nhớ được **10%** những gì họ **đọc** (Sách ảnh học ngôn ngữ ký hiệu tĩnh).
* Người học chỉ ghi nhớ được **20%** những gì họ **nghe** và **30%** những gì họ **nhìn thấy** (Video hướng dẫn 2D).
* Ngược lại, người học ghi nhớ đến **90%** những gì họ **nói và làm trực tiếp** (**Direct, Purposeful Experiences**).

Ứng dụng **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** đã đưa người học xuống vị trí đáy nón trải nghiệm – mức có hiệu quả giáo dục cao nhất. Bằng cách loại bỏ hoàn toàn tay cầm điều khiển (controller) và bắt buộc người chơi sử dụng đôi tay trần của mình để trực tiếp gập các ngón tay và thực hiện cử chỉ ASL trong không gian 3D lập thể, hệ thống kích hoạt **trí nhớ vận động cơ bắp (muscle memory)**. Trải nghiệm "Học thông qua hành động" (Learning-by-doing) này giúp người học hiểu sâu sắc cấu trúc hình học cử chỉ tay và tăng cường hiệu quả lưu giữ kiến thức trong trí nhớ dài hạn lên gấp 9 lần so với đọc sách hay xem video.

---

### 3.1.2 Thuyết tải nhận thức (Cognitive Load Theory)
Thuyết tải nhận thức do John Sweller đề xuất chỉ ra rằng bộ nhớ ngắn hạn hay bộ nhớ làm việc (working memory) của con người có dung lượng lưu trữ cực kỳ giới hạn (chỉ chứa được từ 5 đến 9 đơn vị thông tin cùng một lúc). Khi quá tải nhận thức xảy ra, hiệu quả học tập sẽ bị suy giảm nghiêm trọng. Trong môi trường Thực tế ảo, tải nhận thức dễ bị tăng vọt do người học phải tiếp nhận một lượng lớn thông tin hình ảnh 3D lập thể xung quanh.

Để giải quyết vấn đề này, ứng dụng ASL VR áp dụng 3 quy tắc thiết kế giao diện thông minh nhằm giảm tối đa tải nhận thức ngoại lai (extraneous cognitive load):
1. **Thiết kế giao diện trên cổ tay (`WristDashboardUI`)**: Thay vì hiển thị các menu phẳng lớn lơ lửng che khuất tầm nhìn, toàn bộ bảng điều khiển tiến trình và điểm số được thu gọn vào một menu gắn trên cổ tay người chơi. Menu này chỉ kích hoạt khi người chơi thực hiện động tác xoay ngửa cổ tay tự nhiên, giúp giải phóng không gian lớp học ảo luôn thoáng đãng.
2. **Bảng hiển thị luôn hướng mắt người học (`UIFaceCamera`)**: Tận dụng giải thuật tự động xoay Canvas theo hướng Camera kính HMD, đảm bảo người chơi có thể đứng ở bất kỳ góc nào trong phòng học ảo vẫn đọc được chữ rõ ràng mà không phải tốn tài nguyên não bộ để cố xoay người hay điều chỉnh góc nhìn mắt.
3. **Phản hồi màu sắc trực quan đơn giản**: Hệ thống sử dụng một bảng màu hài hòa, nhất quán và có độ tương phản cao: Màu xanh dương (`COLOR_BLUE`) và xanh lá sáng cho ký tự đúng, màu đỏ cam (`COLOR_RED`) cho lỗi sai, và màu be ấm áp (`COLOR_BEIGE`) cho văn bản chỉ dẫn tĩnh. Sự phân tách màu sắc rõ ràng này giúp bộ não người học xử lý đúng/sai lập tức chỉ trong vài mili-giây mà không cần đọc các văn bản báo lỗi dài dòng.

---

### 3.1.3 Thuyết học tập trải nghiệm (Experiential Learning Theory)
Thuyết học tập trải nghiệm của David Kolb định nghĩa quá trình học tập là một vòng lặp liên tục gồm 4 giai đoạn: Trải nghiệm cụ thể (Concrete Experience) -> Quan sát phản chiếu (Reflective Observation) -> Khái quát hóa khái niệm (Abstract Conceptualization) -> Thử nghiệm chủ động (Active Experimentation).

Ứng dụng ASL VR hiện thực hóa vòng lặp này trong cả chế độ thực hành và kiểm tra:
* **Action (Hành động)**: Người chơi thực hiện một cử chỉ tay ASL theo mẫu.
* **Feedback (Phản hồi)**: Hệ thống nhận diện cử chỉ, phát âm thanh và đổi màu sắc chữ cái ngay lập tức.
* **Reflection (Phản chiếu & Điều chỉnh)**: Nếu chữ đổi màu xanh, người chơi biết mình làm đúng. Nếu chữ giữ màu be hoặc phát tín hiệu sai, người chơi quan sát sự sai lệch giữa tay mình và mẫu của Kyle, khái quát hóa lại góc gập ngón tay và chủ động thử nghiệm lại tư thế tay mới.
Vòng lặp phản hồi siêu tốc này giúp người học tự điều chỉnh hành vi liên tục, tối ưu hóa tốc độ học tập.

---

## 3.2 Cơ sở lý thuyết nhận diện cử chỉ tay trong VR

Công nghệ theo dõi tay (Hand Tracking) trên thiết bị Meta Quest hoạt động bằng cách sử dụng các camera hồng ngoại góc rộng trên kính để bắt giữ hình ảnh bàn tay người chơi, sau đó chạy mô hình AI học sâu trên chip để dựng lại một bộ xương bàn tay ảo (**Hand Skeleton**) gồm **26 khớp xương** (joint) cho mỗi bàn tay.

```
                  [IndexTip] (Ngón trỏ)
                     │
                 [IndexDistal]
                     │
                 [IndexIntermediate]
                     │
                 [IndexProximal]
                     │
                 [IndexMetacarpal]
                     │
                   [Wrist] (Cổ tay)
```

Cơ chế nhận diện cử chỉ trong ứng dụng được phân làm hai loại chính:
1. **Cử chỉ tĩnh (Static Gesture)**: Nhận diện dựa trên góc gập (flexion) và độ duỗi (extension) của từng ngón tay. Mỗi ngón tay (`m_FingerID` từ 0 đến 4) được đo lường các chỉ số góc xoay giữa các khớp xương liền kề. Tư thế tay được công nhận khi tất cả các ngón tay đạt được giá trị mong muốn (`m_Desired`) nằm trong khoảng dung sai cho phép (Upper/Lower Tolerance) được thiết lập sẵn trong các Scriptable Object `XRHandShape` (Ví dụ: Chữ A yêu cầu cả 5 ngón nắm lại, ngón cái áp sát cạnh ngón trỏ).
2. **Cử chỉ hai tay phối hợp (`DualGesture.cs`)**: Hệ thống kiểm tra đồng thời trạng thái nhận diện thành công cử chỉ tĩnh trên cả hai bàn tay trái và phải để công nhận các từ ghép (Ví dụ: từ "Greetings" hoặc từ "ASL" trong một số ngữ cảnh).

---

## 3.3 Thấu hiểu thuật toán $1 Unistroke

Đối với các cử chỉ động có nét vẽ kéo dài như chữ cái **`J`** và **`Z`**, việc nhận diện bằng tư thế khớp ngón tay tĩnh là hoàn toàn không khả thi do hình dạng tay liên tục thay đổi trong quá trình di chuyển. Đồ án giải quyết bài toán này bằng cách phát triển bộ nhận diện quỹ đạo nét vẽ đơn **$1 Unistroke Recognizer** dựa trên nghiên cứu toán học của Wobbrock, Wilson và Li.

Thuật toán hoạt động bằng cách chuyển đổi chuỗi các điểm tọa độ 2D của nét vẽ thu được từ ngón tay người chơi qua **4 bước chuẩn hóa toán học** bắt buộc để đưa nét vẽ về một dạng chuẩn, sẵn sàng so khớp khoảng cách với nét vẽ mẫu:

### Bước 1: Tái mẫu nét vẽ (Resampling)
Chuỗi điểm ban đầu được vẽ với tốc độ di chuyển tay không đều của người chơi, dẫn đến số lượng điểm và khoảng cách giữa các điểm không đồng đều. Thuật toán tiến hành nội suy tuyến tính để chuyển đổi chuỗi điểm gốc thành một chuỗi điểm mới gồm đúng **$N$ điểm cố định** (thường chọn $N = 64$) cách đều nhau về mặt khoảng cách hình học.
Khoảng cách cố định $I$ giữa các điểm được tính bằng tổng chiều dài đường vẽ chia cho $(N - 1)$:
$$I = \frac{\text{PathLength}(P)}{N - 1}$$

### Bước 2: Xoay nét vẽ về góc chỉ báo tiêu chuẩn (Rotation)
Để thuật toán không bị ảnh hưởng bởi góc nghiêng khi vẽ của người chơi, nét vẽ được xoay sao cho góc chỉ báo (góc tạo bởi trọng tâm nét vẽ $C$ và điểm xuất phát đầu tiên $P_0$) trở về bằng $0$ độ.
Trọng tâm $C(x, y)$ của nét vẽ được tính bằng trung bình cộng tọa độ các điểm:
$$C = \left(\frac{1}{N}\sum_{i=1}^N x_i, \frac{1}{N}\sum_{i=1}^N y_i\right)$$
Góc xoay cần thiết $\theta$ được tính bằng:
$$\theta = \arctan2(y_0 - C_y, x_0 - C_x)$$
Mọi điểm trong nét vẽ được xoay quanh tâm $C$ một góc $-\theta$.

### Bước 3: Co dãn nét vẽ về kích thước chuẩn (Scaling)
Nét vẽ sau khi xoay được co dãn sao cho nó nằm gọn trong một hộp bao vuông (Bounding Box) có kích thước chuẩn cố định (ví dụ: $SquareSize = 250$ pixel). Việc này giúp thuật toán nhận diện chính xác nét vẽ bất kể người chơi vẽ chữ to hay nhỏ.
Hộp bao có chiều rộng $W$ và chiều cao $H$. Tọa độ điểm mới được co dãn theo tỉ lệ:
$$q_x = p_x \times \frac{SquareSize}{W}, \quad q_y = p_y \times \frac{SquareSize}{H}$$

### Bước 4: Dịch chuyển về gốc tọa độ (Translation)
Cuối cùng, nét vẽ được dịch chuyển sao cho trọng tâm $C$ trùng hoàn toàn với gốc tọa độ hình học $(0, 0)$.
$$q = p - C$$

### Bước 5: So khớp khoảng cách tối ưu (Golden Section Search)
Nét vẽ của người chơi sau khi qua 4 bước chuẩn hóa sẽ được so sánh với nét vẽ mẫu tiêu chuẩn của chữ **`J`** hoặc **`Z`**. Khoảng cách đường vẽ (Path Distance) giữa nét vẽ của người chơi $P$ và nét vẽ mẫu $T$ được tính bằng trung bình cộng khoảng cách Euclide giữa các cặp điểm tương ứng:
$$\text{PathDistance}(P, T) = \frac{1}{N}\sum_{i=1}^N \sqrt{(p_{i,x} - t_{i,x})^2 + (p_{i,y} - t_{i,y})^2}$$

Do người chơi có thể vẽ lệch góc nhẹ so với mẫu, thuật toán sử dụng phương pháp tìm kiếm tỉ lệ vàng **Golden Section Search (GSS)** với hằng số tỉ lệ $\phi = 0.6180339$ để tìm kiếm góc xoay tối ưu trong khoảng $[-\theta_{range}, \theta_{range}]$ (thường chọn $[-45^\circ, 45^\circ]$) nhằm tìm ra giá trị khoảng cách nhỏ nhất $d_{min}$.

Điểm số khớp lệnh cuối cùng (Recognition Score) được chuẩn hóa về khoảng $[0, 1]$:
$$\text{Score} = 1.0 - \frac{d_{min}}{0.5 \times \sqrt{SquareSize^2 + SquareSize^2}}$$
Nếu điểm số $\text{Score} \ge matchThreshold$ (thiết lập là 0.3), hệ thống sẽ phát hiện thành công nét vẽ động của chữ cái tương ứng.
