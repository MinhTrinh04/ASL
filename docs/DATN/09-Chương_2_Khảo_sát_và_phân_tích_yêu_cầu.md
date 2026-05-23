# CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU

## 2.1 Khảo sát hiện trạng

Để định hình một hướng giải pháp tối ưu và thực tiễn nhất, đồ án tiến hành khảo sát và phân tích hiện trạng các giải pháp học tập Ngôn ngữ ký hiệu Mỹ (ASL) hiện hành trên cả hai môi trường: ứng dụng học 2D truyền thống và ứng dụng thực tế ảo (VR) có sẵn trên cửa hàng Meta Horizon Store.

### 2.1.1 Hạn chế của các giải pháp học tập truyền thống (2D)
* **Học qua giáo trình in ấn / Sách ảnh**: Người học chỉ tiếp xúc với hình ảnh tĩnh chụp tư thế tay. Họ hoàn toàn gặp khó khăn trong việc hình dung cách gập ngón tay trong không gian ba chiều hoặc hướng xoay lòng bàn tay (Ví dụ: sự khác biệt giữa chữ cái `U` và `V`, hay `K` và `P` rất khó mô tả chỉ bằng ảnh chụp thẳng).
* **Học qua video ghi hình sẵn (Youtube / Mobile App)**: Video 2D cung cấp chuyển động liên tục của tay nhưng bị khóa cứng ở góc nhìn của camera lúc quay. Người học không thể xoay nghiêng hoặc quan sát từ trên xuống để thấy rõ chiều sâu của cử chỉ. Ngoài ra, việc tự thực hành trước màn hình điện thoại/máy tính hoàn toàn thiếu cơ chế tự đánh giá độ chính xác cử chỉ, dẫn đến người học không phát hiện ra sai sót của bản thân.

### 2.1.2 Đánh giá các ứng dụng học ASL trong Thực tế ảo hiện có
Hiện nay, trên cửa hàng Meta Horizon Store có một số ứng dụng thực tế ảo thử nghiệm tích hợp tính năng theo dõi bàn tay để dạy ngôn ngữ ký hiệu. Tuy nhiên, các giải pháp này bộc lộ nhiều hạn chế kỹ thuật lớn:
* **Hỗ trợ cử chỉ nghèo nàn**: Đa số các ứng dụng chỉ nhận dạng được các cử chỉ tĩnh cực kỳ cơ bản (ví dụ như chữ cái A, B, C). Họ hoàn toàn bỏ qua các cử chỉ động dạng vẽ nét dài như chữ cái **`J`** và **`Z`** do cảm biến hồng ngoại trên kính VR dễ mất dấu khớp ngón tay khi tay di chuyển vẽ quỹ đạo trong không gian.
* **Thiếu cơ chế bài kiểm tra (Quiz) chuẩn hóa**: Các bài kiểm tra trong game VR hiện tại chủ yếu là trắc nghiệm lý thuyết chọn đáp án bằng tia chỉ laser từ tay cầm, chứ không bắt buộc người học phải dùng chính đôi bàn tay vật lý của mình để đánh vần (spell) một chuỗi từ vựng hoàn chỉnh.
* **Giao diện người dùng phức tạp gây tải nhận thức cao**: Việc hiển thị quá nhiều bảng thông số UI phẳng (2D Canvas) lơ lửng trong không gian ảo 3D gây rối mắt, cản trở tầm nhìn tương tác của đôi tay và làm suy giảm tính nhập vai của người học.

Để làm nổi bật giá trị của giải pháp đề xuất, đồ án xây dựng bảng so sánh chi tiết dưới đây:

#### Bảng 2.1: So sánh tính năng tương tác của giải pháp đề xuất với các ứng dụng hiện tại

| Tính năng so sánh | Sách ảnh / Video 2D truyền thống | Ứng dụng ASL VR hiện tại trên Store | Giải pháp đề xuất của đồ án (**ASL VR Game**) |
|---|---|---|---|
| **Không gian tương tác** | 2D phẳng tĩnh hoặc động bị khóa góc camera | 3D lập thể trong không gian ảo | 3D lập thể nhập vai hoàn toàn |
| **Phương thức tương tác** | Đọc/Xem thụ động, không tương tác trực tiếp | Dùng tay cầm (Controller) hoặc cử chỉ tĩnh rất cơ bản | Tương tác hoàn toàn bằng bàn tay vật lý trần (**Controller-free**) |
| **Độ trễ và phản hồi** | Không có phản hồi đánh giá cử chỉ | Phản hồi chậm, dễ mất dấu khi tay di chuyển nhanh | Phản hồi thời gian thực tức thì (< 0.2s) kèm trực quan hóa màu sắc |
| **Nhận diện cử chỉ động vẽ nét (J, Z)**| Không hỗ trợ | Không hỗ trợ (Bị mất dấu khớp ngón tay) | Hỗ trợ chính xác cao nhờ thuật toán **$1 Unistroke** |
| **Cơ chế thi cử (Quiz)** | Thi trắc nghiệm giấy hoặc ứng dụng điện thoại | Thi trắc nghiệm chọn đáp án bằng nút bấm tay cầm | Thi thực hành đánh vần chuỗi từ thực tế, điền từ vào chỗ trống |
| **Thiết kế UI/UX chống tải nhận thức** | Không áp dụng | UI Canvas phẳng lơ lửng gây cản trở tương tác tay | Menu lật cổ tay ẩn (**Wrist Dashboard**) và Billboard hướng mặt |
| **Cơ chế giảm áp lực phòng thi** | Không có | Không có (Sai là phạt điểm trực tiếp) | Tích hợp **Hidden Mistakes**, **Invincibility Window** giảm ức chế |

---

## 2.2 Tổng quan chức năng

Dựa trên kết quả khảo sát hiện trạng, ứng dụng **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** được thiết kế để phân tách rõ ràng các nhóm chức năng thông qua các sơ đồ Use Case và biểu đồ hoạt động nghiệp vụ.

### 2.2.1 Biểu đồ use case tổng quát
Hệ thống tương tác giữa Người học (Actor: Learner) và ứng dụng VR được mô tả qua biểu đồ Use Case tổng quát:
* **[HÌNH 2.1]**: *Sơ đồ Use Case tổng quan hệ thống thể hiện người học tương tác với 4 ca sử dụng chính: Lựa chọn Topic học tập trên Wrist Dashboard, Học thực hành tương tác lý thuyết, Thực hiện bài thi kiểm tra đánh giá, và Xem tiến trình học tập cá nhân.*

### 2.2.2 Biểu đồ use case phân rã
Để làm rõ chi tiết luồng nghiệp vụ tương tác, đồ án tiến hành phân rã hai ca sử dụng chính:
* **Use Case phân rã ca sử dụng "Học thực hành" (Practice Mode)**:
  * **[HÌNH 2.2]**: *Sơ đồ Use Case phân rã ca sử dụng "Học thực hành". Thể hiện các mối quan hệ tương tác giữa người học với việc xem Kyle làm mẫu, lắng nghe phát âm, thực hiện cử chỉ tĩnh hoặc cử chỉ tương đương, và nhận phản hồi trực quan hóa màu sắc.*
* **Use Case phân rã ca sử dụng "Làm bài kiểm tra" (Quiz Mode)**:
  * **[HÌNH 2.3]**: *Sơ đồ Use Case phân rã ca sử dụng "Làm bài kiểm tra". Thể hiện mối quan hệ giữa người học với Quiz Board để thực hiện 3 dạng câu hỏi: So khớp cử chỉ tay đơn, Đánh vần chuỗi từ khóa (Spelling), Điền từ chỗ trống qua nghe Audio.*

### 2.2.3 Quy trình nghiệp vụ
Luồng vận hành nghiệp vụ từ lúc người học bắt đầu trải nghiệm cho đến khi master các kiến thức được mô tả chi tiết bằng Biểu đồ hoạt động (Activity Diagram):
* **[HÌNH 2.4]**: *Biểu đồ hoạt động luồng nghiệp vụ của người học. Người học khởi động game -> ProgressManager kích hoạt phòng mặc định (Alphabets) -> Teleport người học tới Spawn Point -> Người học kích hoạt Wrist Dashboard để xem tổng quan trạng thái khóa/mở khóa -> Gặp NPC Kyle bấm "Practice" -> Thực hiện chuỗi bài học tương tác -> Hoàn thành bài học thực hành -> Kích hoạt bảng thi Quiz Board -> Thực hiện bài kiểm tra -> QuizManager tính toán điểm số (áp dụng cơ chế Hidden Mistakes, Invincibility Window) -> Lưu điểm qua ProgressManager -> Đạt điểm >= 80%? -> Đúng: Mở khóa phòng thi tiếp theo và quay lại Menu.*

---

## 2.3 Đặc tả chức năng

### 2.3.1 Đặc tả ca sử dụng Học thực hành (Practice Mode)
Ca sử dụng này mô tả quy trình người chơi học các từ vựng ngôn ngữ ký hiệu mới dưới sự chỉ dẫn trực quan của NPC Kyle.

#### Bảng 2.2: Đặc tả chi tiết ca sử dụng "Học thực hành" (Practice Mode)

| Thành phần đặc tả | Mô tả chi tiết ca sử dụng |
|---|---|
| **Tên ca sử dụng** | Học thực hành ngôn ngữ ký hiệu (Practice Mode) |
| **Tác nhân (Actor)** | Người học (Learner) |
| **Mô tả tóm tắt** | Người học đứng trước NPC Kyle, lựa chọn nút thực hành để bắt đầu buổi học. NPC Kyle sẽ lần lượt hiển thị các ký tự hoặc từ vựng cần học, làm mẫu cử chỉ tay. Người học thực hiện theo bằng bàn tay vật lý của mình để hệ thống kiểm tra và hướng dẫn chuyển sang bước tiếp theo. |
| **Tiền điều kiện** | Người học đã kích hoạt Topic tương ứng thành công và được teleport vào phòng học ảo 3D. |
| **Luồng sự kiện chính (Basic Flow)** | 1. Người học nhấn nút "Practice" lơ lửng bên cạnh NPC Kyle.<br>2. Hệ thống tải danh sách bài học ngẫu nhiên (từ `PracticeData`) gồm các chữ cái hoặc từ ghép.<br>3. NPC Kyle chuyển sang trạng thái suy nghĩ (`think` animation) và hiển thị từ khóa cần học lên màn hình hiển thị trực diện phía trên.<br>4. Người học quan sát từ khóa, thực hiện cử chỉ tay tương ứng trước kính VR.<br>5. Cảm biến XR Hands nhận diện tư thế tay của người học, gửi tín hiệu cử chỉ lên hệ thống.<br>6. Hệ thống kiểm tra cử chỉ: Nếu đúng, phần ký tự đó sẽ được tô màu xanh lá sáng rực (`#00FF88`), Kyle thực hiện hoạt ảnh chúc mừng (`correct` animation) và phát âm thanh khích lệ.<br>7. Hệ thống tự động chuyển sang ký tự tiếp theo trong chuỗi từ hoặc chuyển sang từ khóa mới.<br>8. Khi hoàn thành toàn bộ danh sách thực hành, Kyle thực hiện động tác vẫy tay chào và mở khóa nút "Start Exam" để người học sẵn sàng thi. |
| **Luồng sự kiện phụ (Alternative Flow)** | **Nếu người học thực hiện sai cử chỉ**: Ký tự hiển thị trên màn hình giữ nguyên màu mặc định, hệ thống không tính điểm phạt hay trừ lỗi trong chế độ thực hành để người học tự do thử lại liên tục cho đến khi đúng tư thế tay. |
| **Hậu điều kiện** | Người học hoàn thành buổi thực hành, kích hoạt nút thi "Start Exam". |

---

### 2.3.2 Đặc tả ca sử dụng Làm bài kiểm tra (Quiz Mode)
Ca sử dụng này mô tả quy trình người học tham gia kỳ thi kiểm tra đánh giá chất lượng tại Quiz Board để lấy điểm số mở khóa bài học mới.

#### Bảng 2.3: Đặc tả chi tiết ca sử dụng "Làm bài kiểm tra" (Quiz Mode)

| Thành phần đặc tả | Mô tả chi tiết ca sử dụng |
|---|---|
| **Tên ca sử dụng** | Làm bài kiểm tra đánh giá (Quiz Mode) |
| **Tác nhân (Actor)** | Người học (Learner) |
| **Mô tả tóm tắt** | Người học tương tác với bảng thi Quiz Board 3D. Hệ thống lần lượt hiển thị câu hỏi (đọc hiểu ảnh cử chỉ, đánh vần chuỗi, hoặc điền từ qua nghe audio). Người học thực hiện cử chỉ tay để trả lời. QuizManager tính điểm và ghi nhận tiến trình. |
| **Tiền điều kiện** | Người học đã hoàn thành phần học thực hành với Kyle hoặc nhấn chọn cổng thi "Start Exam". |
| **Luồng sự kiện chính (Basic Flow)** | 1. Người học nhấn nút "Start Exam", ClassroomManager ẩn `lecturePhase` và kích hoạt `quizPhase` hiển thị bảng thi Quiz Board 3D.<br>2. `QuizManager` tải danh sách câu hỏi kiểm tra từ danh sách `questionList` (cấu trúc từ `QuizData`).<br>3. Hệ thống hiển thị câu hỏi và phát âm thanh hướng dẫn tương ứng (nếu có).<br>4. Người học thực hiện cử chỉ tay để trả lời. Nếu câu trả lời trùng khớp với đáp án chính xác trong tệp dữ liệu:<br>&nbsp;&nbsp;&nbsp;&nbsp;- Hệ thống phát âm thanh đúng (`correctClip`), tô chữ màu xanh dương (`COLOR_BLUE`).<br>&nbsp;&nbsp;&nbsp;&nbsp;- Cộng điểm số tương ứng (`score += pointPerPart`).<br>&nbsp;&nbsp;&nbsp;&nbsp;- Nếu hoàn thành câu hỏi, hệ thống chờ `interQuestionDelay` (2.0s) hiển thị chữ "PERFECT!" rồi chuyển câu mới.<br>5. Sau khi hoàn thành câu hỏi cuối cùng, hệ thống tính tổng điểm phần trăm, báo cáo điểm về `ProgressManager.Instance.SaveTopicScore(topicIndex, percentage)`. Nếu điểm >= 80%, thông báo "Topic Mastered! Next unlocked".<br>6. Sau 5 giây, hệ thống tự động đưa người chơi trở lại chế độ học lý thuyết. |
| **Luồng sự kiện phụ (Alternative Flow)** | **Nếu người học thực hiện sai cử chỉ (Wrong input path)**:<br>1. Hệ thống kiểm tra xem cử chỉ mong đợi có nằm trong danh sách miễn phạt (`noPenaltyGestures` như J, Z) hay không. Nếu có: Bỏ qua không phạt lỗi, cho phép người học thử lại thoải mái.<br>2. Nếu không thuộc diện miễn phạt, hệ thống tăng chỉ số sai lầm ẩn (`hiddenMistakes++`). Khi `hiddenMistakes >= 3`, hệ thống mới quy đổi thành 1 lỗi phạt chính thức (`currentQuestionMistakes++`) và phát âm thanh sai (`wrongClip`).<br>3. Khi có 1 lỗi phạt chính thức đầu tiên: Kích hoạt chế độ vô địch ẩn trong vòng `invincibilityDuration` (2.5s) giúp người học không bị phạt thêm lỗi trong quá trình điều chỉnh ngón tay.<br>4. Nếu `currentQuestionMistakes >= 3` (mắc 3 lỗi phạt chính thức): Hệ thống thông báo vượt quá số lỗi cho phép, tự động nhảy sang câu hỏi tiếp theo để tránh gây ức chế tâm lý cho người học. |
| **Hậu điều kiện** | Điểm số bài thi được lưu trữ cục bộ, mở khóa module học tập mới nếu đạt điểm đỗ. |

---

## 2.4 Yêu cầu phi chức năng

Để một ứng dụng Thực tế ảo vận hành mượt mà và thực sự mang lại giá trị giáo dục, các yêu cầu phi chức năng sau là bắt buộc phải đạt được:

### 2.4.1 Yêu cầu về mặt hiệu suất kỹ thuật (Performance)
* **Khung hình hiển thị ổn định (FPS)**: Phải duy trì tối thiểu **72 FPS** (tốt nhất là **90 FPS**) trên thiết bị kính Meta Quest 2 standalone. Trong môi trường thực tế ảo, khung hình tụt đột ngột (jitter) dưới 60 FPS sẽ gây hiện tượng nhức đầu, chóng mặt và buồn nôn cho người học (hiện tượng **VR Motion Sickness**).
* **Độ trễ nhận dạng cực thấp (Latency)**: Thời gian từ lúc người học thực hiện động tác tay vật lý đến lúc UI trực quan hiển thị màu sắc phản hồi phải nhỏ hơn **0.2 giây**. Độ trễ lớn hơn sẽ phá vỡ liên kết nhận thức vận động của não bộ người học.
* **Thời gian tải màn chơi (Loading time)**: Thời gian chuyển đổi giữa các Classroom và tải câu hỏi trắc nghiệm mới phải dưới **2.0 giây**.

### 2.4.2 Yêu cầu về độ chính xác và khả năng thích ứng (Accuracy & Usability)
* **Tỉ lệ nhận diện chính xác**: Đạt tối thiểu **85%** đối với các cử chỉ tay tĩnh trong điều kiện ánh sáng phòng học bình thường. Hệ thống phải thích ứng tốt với nhiều kích cỡ tay khác nhau của người học.
* **Hạn chế nhiễu cử chỉ**: Hệ thống lọc bỏ hoàn toàn các tư thế tay rác hoặc tư thế thả lỏng tự nhiên (`Idle`, `None`) để tránh nhận dạng nhầm đáp án khi người chơi đang nghỉ tay.

### 2.4.3 Yêu cầu về mặt thiết kế giao diện (UI/UX)
* **Billboard hướng mặt (`UIFaceCamera`)**: Tất cả các bảng hiển thị văn bản hướng dẫn và UI 3D trong không gian ảo phải tự động xoay hướng mặt về phía Camera kính HMD của người chơi theo trục Y để đảm bảo người học luôn nhìn rõ chữ ở mọi góc đứng thực hành.
* **Wrist Dashboard**: Bảng tiến trình học tập gắn trên cổ tay chỉ hiển thị khi người chơi ngửa cổ tay một góc tự nhiên từ 60 - 90 độ, giúp giữ không gian học tập luôn gọn gàng và không bị cản trở tầm nhìn tương tác của đôi tay.
