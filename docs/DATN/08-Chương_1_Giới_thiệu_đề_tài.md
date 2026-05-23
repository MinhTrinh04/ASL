# CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI

## 1.1 Đặt vấn đề

Ngôn ngữ là phương tiện giao tiếp cơ bản nhất của loài người, đóng vai trò quyết định trong việc truyền đạt thông tin, tư duy và kết nối xã hội. Đối với cộng đồng người khiếm thính và người gặp khó khăn trong việc nói, ngôn ngữ ký hiệu (Sign Language) là chiếc cầu nối duy nhất giúp họ hòa nhập với thế giới xung quanh. Trong số các hệ thống ngôn ngữ ký hiệu trên thế giới, Ngôn ngữ ký hiệu Mỹ (ASL - American Sign Language) là hệ thống phổ biến nhất, được sử dụng rộng rãi không chỉ ở Bắc Mỹ mà còn được coi là ngôn ngữ ký hiệu quốc tế trong nhiều hội thảo khoa học và giáo dục đặc biệt.

Tuy nhiên, việc tiếp cận và học tập ngôn ngữ ký hiệu ASL đối với người nghe bình thường (người có mong muốn làm tình nguyện viên, người thân của người khiếm thính, hoặc nhà giáo dục đặc biệt) đang gặp rất nhiều rào cản. Các phương pháp giáo dục truyền thống hiện hành bộc lộ nhiều hạn chế lớn:
1. **Thiếu tính đa chiều trực quan**: Việc học qua sách ảnh tĩnh hoặc video 2D trên Youtube/Website chỉ hiển thị cử chỉ tay trên một mặt phẳng dẹt. Ngôn ngữ ký hiệu ASL là một ngôn ngữ không gian phức tạp, yêu cầu sự phối hợp chính xác của ba yếu tố: hình dạng bàn tay (hand shape), vị trí tay so với cơ thể (hand position), và chuyển động động học của tay trong không gian ba chiều (hand movement). Các tài liệu 2D hoàn toàn thất bại trong việc mô tả chiều sâu và sự chuyển động liên tục này.
2. **Thiếu cơ chế phản hồi tức thời (Feedback loop)**: Khi tự học qua video, người học tự thực hiện động tác nhưng không có giáo viên bên cạnh chỉnh sửa. Họ không thể biết cử chỉ của mình đã đúng độ gập ngón tay, hướng lòng bàn tay hay chưa. Sự sai lệch lâu ngày dẫn đến thói quen sai lầm, làm biến đổi hoàn toàn ngữ nghĩa của từ vựng ký hiệu.
3. **Thiếu động lực học tập và dễ nản lòng**: Học ngôn ngữ ký hiệu đòi hỏi sự lặp đi lặp lại của các cơ ngón tay để tạo trí nhớ cơ bắp (muscle memory). Các giáo trình học chay hoặc bài tập giấy khô khan nhanh chóng tạo cảm giác nhàm chán, dẫn đến tỉ lệ bỏ cuộc cao ở người tự học.

Sự phát triển vượt bậc của công nghệ Thực tế ảo (Virtual Reality - VR), đặc biệt là sự phổ cập của các thiết bị kính VR độc lập (standalone HMD) như Meta Quest 2 và Quest 3, đã mở ra cơ hội giải quyết triệt để các vấn đề trên. Với công nghệ cảm biến theo dõi tay vật lý trực tiếp không cần tay cầm điều khiển (**Controller-free Hand Tracking**), người học có thể đặt kính lên đầu, sử dụng chính đôi tay trần của mình để tương tác trực quan trong không gian ảo 3D. 

Từ thực tiễn đó, đồ án lựa chọn nghiên cứu và phát triển đề tài **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"**. Đây là một ứng dụng EdTech VR tiên phong tích hợp công nghệ theo dõi tay, mang lại một phương pháp học tập ASL hoàn toàn mới: học tập qua trải nghiệm tương tác trực tiếp 3D và nhận phản hồi đánh giá cử chỉ thời gian thực chính xác.

---

## 1.2 Mục tiêu và phạm vi đề tài

### 1.2.1 Mục tiêu đề tài
Mục tiêu tổng quát của đồ án là nghiên cứu và xây dựng một ứng dụng học ngôn ngữ ký hiệu ASL tương tác nhập vai trong môi trường Thực tế ảo, đạt được các mục tiêu cụ thể sau:
* **Mục tiêu kỹ thuật**: Triển khai hệ thống nhận diện tư thế tay tĩnh và cử chỉ động chính xác cao, thời gian phản hồi nhanh (< 0.2s) dựa trên công nghệ Unity XR Hands SDK và thuật toán nhận dạng nét vẽ $1 Unistroke trên kính Meta Quest 2 độc lập.
* **Mục tiêu sư phạm (EdTech)**: Thiết kế giao diện và luồng bài giảng dựa trên các lý luận giáo dục hiện đại (Nón trải nghiệm Edgar Dale, Thuyết tải nhận thức) để tối ưu hóa khả năng tiếp thu và ghi nhớ vận động của người học.
* **Mục tiêu trò chơi hóa (Gamification)**: Tích hợp các cơ chế kiểm tra sinh động, bảng điểm lưu trữ tiến trình học tập, và các thuật toán giảm thiểu ức chế tâm lý làm bài thi (Hidden Mistakes, Invincibility Window) nhằm kích thích động lực học tập liên tục của người dùng.

### 1.2.2 Phạm vi đề tài
* **Đối tượng thiết bị**: Kính thực tế ảo standalone Meta Quest 2 và Quest 3, chạy trên hệ điều hành Android (Oculus OS), sử dụng tương tác hoàn toàn bằng bàn tay vật lý của người chơi (không dùng controller).
* **Nội dung giáo trình**: Hệ thống bài học được chuẩn hóa thành 3 chủ đề học tập cốt lõi bao gồm:
  1. *Bảng chữ cái (Alphabets)*: 26 chữ cái tiếng Anh từ A đến Z, bao gồm cả các chữ cái tĩnh và các chữ cái động có nét vẽ phức tạp (J, Z).
  2. *Chữ số (Numbers)*: Các chữ số cơ bản từ 0 đến 20 và các phép toán kiểm tra số học.
  3. *Chào hỏi và từ vựng thông dụng (Greetings)*: Các từ vựng giao tiếp cơ bản (Hello, Thank you, Name, Goodbye, What's up...) sử dụng cả cử chỉ một tay, hai tay phối hợp (Dual Gesture) và cử chỉ động chuyển đổi trạng thái (Dynamic Gesture).

---

## 1.3 Định hướng giải pháp

Để đạt được các mục tiêu trên, đồ án đề xuất giải pháp kỹ thuật và sư phạm đồng bộ như sau:

### 1.3.1 Định hướng công nghệ phần mềm
* **Unity Engine (2022.3 LTS)**: Sử dụng làm nền tảng phát triển cốt lõi để xây dựng thế giới 3D phòng học và quản lý các tài nguyên đồ họa, âm thanh.
* **OpenXR & Unity XR Hands SDK**: Tận dụng các API theo dõi tay (Hand Tracking) chuẩn hóa để thu thập cấu hình xương bàn tay (26 khớp xương mỗi bàn tay) thời gian thực từ camera hồng ngoại của kính Meta Quest.
* **Kiến trúc hướng sự kiện (Event-Driven)**: Tách rời module cảm biến tay và module xử lý logic thông qua bộ môi giới sự kiện tĩnh trung tâm `GestureHub`. Mọi cử chỉ tay sau khi được nhận dạng thành công sẽ kích hoạt các sự kiện toàn cục, giúp các thành phần như `QuizManager` hay `NPCKyleController` đăng ký sử dụng linh hoạt mà không bị chồng chéo mã nguồn.
* **Thuật toán chiếu tọa độ và $1 Unistroke**: Phát triển module thu thập tọa độ ngón tay vẽ quỹ đạo `VRMagicTrajectory`, chiếu tọa độ 3D của ngón trỏ lên mặt phẳng 2D cục bộ song song với Camera người chơi và chuyển tiếp sang bộ thư viện toán học nhận diện nét vẽ $1 Unistroke tự phát triển để nhận diện các ký hiệu chuyển động vẽ như chữ J và Z.

### 1.3.2 Thiết kế trải nghiệm EdTech
* **Thiết kế phòng học ảo 3D**: Người học được teleport qua các phòng học chuyên biệt tương ứng với từng Topic để tăng tính nhập vai và tập trung nhận thức.
* **Tương tác trực tiếp với NPC Kyle**: Người học xem Kyle (NPC ảo) thực hiện cử chỉ mẫu, nghe phát âm và thực hành theo. Hệ thống trực quan hóa kết quả ngay trên chữ cái bằng màu sắc (xanh dương là đúng, đỏ là sai).
* **Bảng điều khiển cổ tay (Wrist Dashboard)**: Tận dụng chuyển động lật ngửa cổ tay để hiển thị menu trạng thái học tập nhanh, giúp giảm tải nhận thức giao diện (UI) chiếm không gian phòng học ảo.

---

## 1.4 Bố cục đồ án

Nội dung thuyết minh đồ án tốt nghiệp được tổ chức thành 6 chương chính như sau:
* **CHƯƠNG 1. GIỚI THIỆU ĐỀ TÀI**: Đặt vấn đề, mục tiêu, phạm vi nghiên cứu, định hướng giải pháp kỹ thuật - sư phạm và bố cục đồ án.
* **CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU**: Khảo sát các giải pháp học ngôn ngữ ký hiệu hiện hành, phân tích ca sử dụng (Use Case), biểu đồ hoạt động nghiệp vụ (Activity Diagram) và đặc tả chi tiết các chức năng học/thi cùng yêu cầu phi chức năng.
* **CHƯƠNG 3. NỀN TẢNG LÝ THUYẾT VÀ CÔNG NGHỆ SỬ DỤNG**: Cơ sở lý luận EdTech (Nón trải nghiệm Edgar Dale, Thuyết tải nhận thức), công nghệ Unity XR Hands, lý thuyết cử chỉ tay và cơ sở toán học của thuật toán $1 Unistroke.
* **CHƯƠNG 4. PHÂN TÍCH THIẾT KẾ, TRIỂN KHAI VÀ ĐÁNH GIÁ HỆ THỐNG**: Thiết kế kiến trúc phần mềm Event-Driven chi tiết, thiết kế sơ đồ lớp (Class Diagram), sơ đồ gói (Package Diagram), thiết kế giao diện UI/UX cổ tay, cấu trúc dữ liệu ScriptableObject, kết quả xây dựng ứng dụng thực tế và quy trình kiểm thử/triển khai.
* **CHƯƠNG 5. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT**: Phân tích chi tiết 3 đóng góp khoa học chính gồm giải pháp chiếu nét vẽ 2D cục bộ cho chữ cái J/Z, cơ chế Gamification giảm áp lực thi cử và đăng ký các Module có khả năng tái sử dụng cao (`GestureHub`, `TrajectoryRecognizer`, `QuizManager`).
* **CHƯƠNG 6. KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN**: Tổng kết các kết quả đạt được, tự đánh giá ưu khuyết điểm của ứng dụng và đề xuất các hướng phát triển nâng cao trong tương lai.
