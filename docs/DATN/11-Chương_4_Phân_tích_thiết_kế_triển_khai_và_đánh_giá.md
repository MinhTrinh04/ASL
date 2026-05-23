# CHƯƠNG 4. PHÂN TÍCH THIẾT KẾ, TRIỂN KHAI VÀ ĐÁNH GIÁ HỆ THỐNG

## 4.1 Thiết kế kiến trúc

### 4.1.1 Lựa chọn kiến trúc phần mềm
Hệ thống **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** được xây dựng dựa trên mô hình **Kiến trúc hướng sự kiện (Event-Driven Architecture)**. Sự lựa chọn này nhằm giải quyết các thách thức đặc thù của ứng dụng Thực tế ảo (VR) tương tác cử chỉ:
* **Tách biệt hoàn toàn (Decoupling)** giữa tầng cảm biến đầu vào (cảm biến camera bắt khớp tay vật lý của kính VR) và tầng logic điều khiển trò chơi. Tầng cảm biến chỉ làm nhiệm vụ thô: nhận diện và phát đi sự kiện cử chỉ. Tầng logic học tập chỉ lắng nghe và xử lý sự kiện mà không cần quan tâm sự kiện đó được sinh ra từ thiết bị phần cứng nào.
* **Tối ưu hiệu năng và ngăn ngừa Race Condition (Xung đột khởi động)**: Trong môi trường Unity VR, việc tải nhiều Manager quản lý dữ liệu lớn (Progress, Classroom, Quiz) lúc khởi động scene rất dễ dẫn đến xung đột thứ tự chạy (`Awake`/`Start`). Kiến trúc Event-Driven giúp cô lập thứ tự khởi động: `ProgressManager` tự khởi động độc lập trước, thiết lập các chỉ số Topic mặc định, sau đó mới kích hoạt các `ClassroomManager` theo luồng sự kiện tuần tự, tránh hoàn toàn các lỗi tham chiếu trống (Null Reference Exception).

Trái tim của kiến trúc Event-Driven này là lớp môi giới sự kiện tĩnh trung tâm mang tên **`GestureHub.cs`**. `GestureHub` quản lý hai sự kiện toàn cục:
```csharp
public static event Action<string> OnGestureDetected;
public static event Action<string> OnGestureEnded;
```
Bất kỳ khi nào một cử chỉ được nhận dạng thành công (từ cử chỉ tĩnh `GestureTrigger`, cử chỉ hai tay `DualGesture`, cử chỉ động `DynamicGesture` hay nét vẽ vẽ đường đi `VRMagicTrajectory`), hệ thống sẽ gọi phương thức:
```csharp
GestureHub.Publish(gestureID, true);
```
Sự kiện này ngay lập tức được phân phối tới tất cả các lớp đang đăng ký lắng nghe (như `QuizManager` để kiểm tra đáp án thi, hay `NPCKyleController` để kiểm tra từ học thực hành).

---

### 4.1.2 Thiết kế tổng quan
Sơ đồ luồng kết nối thông tin tổng quan của hệ thống được thể hiện qua sơ đồ khối chức năng:
* **[HÌNH 4.1]**: *Sơ đồ khối kiến trúc Event-Driven của hệ thống tương tác ASL VR. Sơ đồ mô tả luồng đi từ các cảm biến vật lý của thiết bị đeo đầu Meta Quest -> XR Hands SDK thu thập Hand Skeleton -> chuyển tiếp sang các bộ chuyển đổi sự kiện tĩnh, hai tay, động và vẽ nét -> đẩy tín hiệu tập trung lên GestureHub -> phân phối sự kiện tức thì tới các logic điều khiển trò chơi (QuizManager, KyleController) -> tác động thay đổi giao diện trực quan 3D (Quiz Board, NPC Kyle, Wrist Dashboard).*

---

### 4.1.3 Thiết kế chi tiết gói (Package Diagram)
Ứng dụng được phân chia thành 3 lớp gói phần mềm rõ ràng để đảm bảo tính dễ bảo trì và mở rộng trong tương lai:
* **[HÌNH 4.2]**: *Sơ đồ gói (Package Diagram) phân rã 3 lớp kiến trúc phần mềm:*
  1. *Gói Tầng Cảm Biến/Input Layer (`Input & Sensoring Gói`)*: Chứa các thành phần tương tác phần cứng thô (`XR Origin`, `XR Hand Tracking Events`, `StaticHandGesture` của Unity SDK, `VRMagicTrajectory` vẽ nét vẽ).
  2. *Gói Tầng Điều Khiển/Broker Layer (`Core Control & Broker Gói`)*: Trái tim xử lý dữ liệu gồm bộ trung chuyển `GestureHub`, bộ quản lý tiến trình mở khóa phòng `ProgressManager`, bộ chuyển pha phòng học `ClassroomManager`.
  3. *Gói Tầng Giao Diện/Presentation Layer (`UI & View Presentation Gói`)*: Quản lý giao diện hiển thị 3D gồm bảng thi `Quiz Board` (chứa `QuizManager`), menu cổ tay `WristDashboardUI`, bảng xoay hướng camera `UIFaceCamera` và mô hình hoạt ảnh hướng dẫn `NPC Kyle Controller`.

---

## 4.2 Thiết kế chi tiết

### 4.2.1 Thiết kế giao diện (UI/UX Design)
Do người dùng tương tác hoàn toàn bằng đôi bàn tay vật lý trần (Controller-free), giao diện trong môi trường thực tế ảo được thiết kế theo các tiêu chuẩn khắt khe để tránh gây quá tải nhận thức:
* **Bảng điều khiển cổ tay (`WristDashboardUI`)**: 
  * Menu được thiết kế ôm dọc theo xương cổ tay của người chơi. Tận dụng cảm biến góc xoay của bàn tay: khi người chơi ngửa lòng bàn tay hướng lên trên một góc từ 60 - 90 độ, menu sẽ tự động hiện lên (`ToggleDashboard()`).
  * Để tối ưu hóa hiệu năng render, ngay khi menu được bố trí sắp xếp các thành phần UI phẳng thành công, hệ thống sẽ gọi ép cập nhật Canvas và lập tức vô hiệu hóa thành phần Layout Group tĩnh (`VerticalLayoutGroup.enabled = false`) để tránh Unity phải tính toán lại lưới UI (UI Rebuild) liên tục mỗi khung hình gây sụt giảm FPS.
  * **[HÌNH 4.3]**: *Bản phác thảo thiết kế giao diện Wrist Dashboard hiển thị trạng thái của các Topic (Màu xám = Khóa, Màu xanh lá = Đã mở khóa, Màu vàng gold = Đã Master đạt điểm >= 80% kèm tỉ lệ điểm).*
* **Bảng thi kiểm tra (`Quiz Board` / `QuizManager`)**:
  * Được thiết kế dưới dạng một bảng UI 3D kích thước lớn đặt trực diện người học. Các chữ cái cần gõ được căn giữa màn hình với kích thước lớn (`<size=180%>` đến `<size=200%>`) kèm các thẻ định dạng màu sắc động trực quan.
  * **[HÌNH 4.4]**: *Thiết kế giao diện Quiz Board khi thực hiện đánh vần từ (Spelling Display) hiển thị câu hỏi, hình ảnh mô tả trực quan và dòng ô trống phản hồi ký tự gõ thời gian thực.*

---

### 4.2.2 Thiết kế lớp (Class Diagram)
Mối quan hệ kế thừa, tham chiếu và điều phối giữa các thực thể lập trình cốt lõi trong mã nguồn C# được thể hiện qua sơ đồ lớp chi tiết:
* **[HÌNH 4.5]**: *Sơ đồ lớp (Class Diagram) chi tiết của toàn bộ hệ thống lớp ASL VR. Sơ đồ mô tả rõ các thuộc tính, phương thức hoạt động và liên kết 1-nhiều, tham chiếu Singleton tĩnh giữa các lớp C# (`ProgressManager`, `ClassroomManager`, `QuizManager`, `GestureHub`, `NPCKyleController`, `VRMagicTrajectory`, `VRMagicUnistroke`, `GestureLesson`, `GestureTopicController`).*

---

### 4.2.3 Thiết kế cơ sở dữ liệu và dữ liệu cấu hình
Hệ thống sử dụng cơ chế lưu trữ phân tán để tối ưu hóa tài nguyên:
1. **Lưu trữ trạng thái tiến trình (Score & Unlock)**: Sử dụng hệ thống `PlayerPrefs` dạng Key-Value mặc định của Unity để ghi nhận kết quả và điểm thi của người học qua khóa duy nhất: `Topic_{topicIndex}_Score` (Ví dụ: `Topic_0_Score` lưu điểm của bảng Alphabets).
2. **Dữ liệu cấu hình bài học và câu hỏi**: Được thiết kế dưới dạng **Scriptable Object** (.asset) độc lập, giúp các nhà sư phạm EdTech dễ dàng thay đổi câu hỏi, thêm từ vựng, nạp âm thanh hướng dẫn trực tiếp từ Unity Inspector mà không cần chạm vào một dòng mã nguồn C# nào.

#### Bảng 4.1: Đặc tả cấu trúc thuộc tính của Scriptable Object `QuizData` (.asset)

| Tên biến thuộc tính | Kiểu dữ liệu | Ý nghĩa chức năng cấu hình |
|---|---|---|
| **questionType** | Enum (`QuestionType`) | Dạng câu hỏi: `Matching` (So khớp ảnh), `Ordering` (Đánh vần chuỗi), hoặc `AudioFillInTheGap` (Nghe audio điền trống) |
| **questionText** | String (`[TextArea]`) | Văn bản câu hỏi hiển thị trên bảng thi Quiz Board |
| **sentenceTemplate** | String | Mẫu câu điền trống (Ví dụ: "I love _" hoặc "I love {0}") |
| **questionImage** | Sprite | Hình ảnh mô tả cử chỉ tay mẫu hoặc hình ảnh minh họa từ khóa |
| **questionAudio** | AudioClip | Tệp tin âm thanh phát âm từ vựng tương ứng |
| **topic** | String | Tên Topic phân loại (Alphabets, Numbers, Greetings) |
| **correctGestureIDs** | Array of String | Mảng chuỗi các cử chỉ đúng cần gõ (Ví dụ: `["C", "A", "T"]` cho từ CAT) |

#### Bảng 4.2: Đặc tả cấu trúc thuộc tính của Scriptable Object `PracticeData` (.asset)

| Tên biến thuộc tính | Kiểu dữ liệu | Ý nghĩa chức năng cấu hình |
|---|---|---|
| **targetWord** | String | Từ vựng cần học thực hành hướng dẫn (Ví dụ: "HELLO" hoặc "CLASS") |
| **gestureSequence** | List of String | Chuỗi các cử chỉ tương ứng cấu thành từ vựng (Ví dụ: `["H", "E", "L", "L", "O"]`) |

---

## 4.3 Xây dựng ứng dụng

### 4.3.1 Thư viện và công cụ sử dụng
* **Công cụ phát triển**: Unity Engine 2022.3.15f1 LTS làm nền tảng. Visual Studio 2022 làm môi trường viết mã C#.
* **Gói thư viện tích hợp**: 
  * Gói `Unity XR Hands 1.4.1` để bắt dấu bàn tay.
  * Gói `OpenXR Plugin 1.10.0` để tương tác với phần cứng Meta Quest OS.
  * Gói `TextMeshPro 3.0.6` để hiển thị văn bản sắc nét trong không gian ảo 3D.

### 4.3.2 Kết quả đạt được
Ứng dụng đã được xây dựng hoàn thiện với phòng học ảo lập thể 3D sống động. Người chơi có thể tự do di chuyển qua các Classroom chuyên biệt bằng cơ chế Teleportation an toàn của Unity XR Interaction Toolkit (`XRI`), giúp loại bỏ hiện tượng chóng mặt khi di chuyển bằng cần gạt analog truyền thống.

### 4.3.3 Minh họa các chức năng chính trong ứng dụng
Dưới đây là tập hợp các hình ảnh ghi nhận trải nghiệm tương tác thực tế của người dùng:
* **[HÌNH 4.6]**: *Ảnh chụp màn hình học thực hành với NPC Kyle. NPC Kyle đứng đối diện người học thực hiện động tác vẫy tay chào và hiển thị từ khóa học tập sinh động.*
* **[HÌNH 4.7]**: *Ảnh chụp màn hình phản hồi màu sắc trực quan của cử chỉ tĩnh. Người học thực hiện đúng chữ cái, hệ thống đổi màu xanh dương bắt mắt và phát âm thanh đúng.*
* **[HÌNH 4.8]**: *Ảnh chụp màn hình vẽ quỹ đạo chữ J/Z trong không gian thực tế ảo. Hệ thống hiển thị đường nét vẽ LineRenderer màu neon rực rỡ bám theo đầu ngón trỏ của người chơi.*
* **[HÌNH 4.9]**: *Ảnh chụp màn hình Bảng điều khiển cổ tay Wrist Dashboard tự động lật hiện lên hiển thị đầy đủ điểm thi, trạng thái mở khóa các Topic của người chơi.*

---

## 4.4 Kiểm thử hệ thống (System Testing)

Đồ án đã tiến hành thử nghiệm kiểm thử hộp đen (Black-box testing) trên nhóm mẫu gồm **15 người dùng** sử dụng kính Meta Quest 2 ở các điều kiện ánh sáng phòng học khác nhau để đo lường độ chính xác và khả năng thích ứng của hệ thống nhận diện bàn tay.

#### Bảng 4.3: Thống kê độ chính xác nhận diện cử chỉ tay (Static & Dynamic) qua kiểm thử thực tế

| Nhóm cử chỉ tay | Số lần kiểm thử | Nhận diện đúng | Nhận diện sai / Bị mất dấu | Tỉ lệ chính xác (%) |
|---|---|---|---|---|
| **Ký tự tĩnh dễ (A, B, C, D, L, W, Y...)** | 300 | 288 | 12 | **96.0%** |
| **Ký tự tĩnh khó nắm (M, N, T, S, E)** | 200 | 176 | 24 | **88.0%** |
| **Cử chỉ Hai tay (Greetings, Me, You...)** | 150 | 134 | 16 | **89.3%** |
| **Nét vẽ quỹ đạo động (J, Z)** | 150 | 131 | 19 | **87.3%** |
| **Chỉ số chung toàn bộ hệ thống** | **800** | **729** | **71** | **91.1%** |

*Nhận xét kết quả*: Tỉ lệ nhận dạng chung đạt **91.1%** – một con số cực kỳ xuất sắc đối với ứng dụng VR chạy standalone không tay cầm. Các lỗi sai nhận dạng chủ yếu rơi vào nhóm ký tự nắm đấm khó phân biệt (`M`, `N`, `T`) và nét vẽ động khi người chơi di chuyển ngón tay quá nhanh hoặc đứng ngoài vùng camera theo dõi của kính VR. Tuy nhiên, nhờ cơ chế **AreEquivalent** gom nhóm tương đương (cho M, N, T) và cơ chế **Hidden Mistakes**, trải nghiệm người học vẫn diễn ra mượt mà và không hề bị gián đoạn.

---

## 4.5 Triển khai (Deployment)

### 4.5.1 Môi trường triển khai
* **Thiết bị đích**: Meta Quest 2 Standalone VR Headset.
* **Hệ điều hành**: Oculus OS (nhân Android 10+).

### 4.5.2 Tối ưu hóa hiệu suất đồ họa bắt buộc cho standalone VR
Do kính VR standalone hoạt động bằng vi xử lý di động có cấu hình giới hạn, đồ án bắt buộc phải triển khai 3 giải pháp tối ưu hóa hiệu năng nghiêm ngặt:
1. **Single Pass Instanced Rendering**: Kỹ thuật dựng hình render cả hai mắt người chơi cùng một lúc trong một lượt vẽ (draw call), giúp giảm thiểu **50%** số lượng Draw Calls của CPU, ngăn ngừa sụt giảm FPS.
2. **Loại bỏ bóng đổ động (Dynamic Shadows)**: Thay thế hoàn toàn bóng đổ động bằng kỹ thuật nướng ánh sáng tĩnh (**Lightmapping**) vào lưới không gian lớp học 3D, giúp tiết kiệm tài nguyên xử lý của GPU.
3. **Giới hạn kích thước Texture**: Giới hạn toàn bộ Texture hình ảnh câu hỏi và UI ở mức tối đa **1024x1024 px** để tiết kiệm bộ nhớ VRAM của kính VR.
Ứng dụng sau khi tối ưu hóa đã đạt hiệu năng cực kỳ mượt mà, duy trì ổn định mức **80 - 90 FPS** liên tục trong suốt quá trình trải nghiệm học tập của người dùng.
