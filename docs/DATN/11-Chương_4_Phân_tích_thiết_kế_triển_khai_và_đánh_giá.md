# CHƯƠNG 4. THIẾT KẾ BÀI GIẢNG, TRIỂN KHAI VÀ ĐÁNH GIÁ HỆ THỐNG

Chương này trình bày chi tiết về triết lý thiết kế bài giảng tương tác, các cơ chế sư phạm trực quan, hệ thống điều khiển tay trần tự nhiên, kiến trúc phần mềm hướng sự kiện, kết quả triển khai thực tế và quy trình kiểm thử đánh giá hiệu năng hệ thống trên kính Meta Quest 2.

---

## 4.1 Mục tiêu của bài giảng

Định hướng sư phạm cốt lõi của bài giảng **"Ngôn ngữ ký hiệu trong Thực tế ảo"** không chỉ dừng lại ở việc cung cấp kiến thức lý thuyết thụ động mà hướng tới việc giúp người học làm chủ các kỹ năng thực hành ngôn ngữ ký hiệu thông qua phản xạ vận động tự nhiên. Các mục tiêu cụ thể bao gồm:

- **Về mặt kiến thức**: Giúp người học nhận diện, ghi nhớ và thực hiện chính xác 26 ký tự đơn trong bảng chữ cái tiếng Anh, các chữ số cơ bản từ 0 đến 9 và các từ vựng giao tiếp thông dụng trong đời sống hàng ngày.
- **Về mặt vận động cơ bắp**: Loại bỏ sự phụ thuộc vào các phím bấm cơ học của tay cầm VR, bắt buộc người học sử dụng chính đôi bàn tay vật lý trần của mình để uốn nắn các khớp ngón tay theo cấu trúc không gian 3D. Từ đó, hình thành vùng ký ức vận động dài hạn một cách tự nhiên và chính xác.
- **Về mặt tương tác sư phạm**: Tạo ra một môi trường học tập lập thể 3D sinh động, nơi người học có thể tự chủ động tương tác với giảng viên ảo, tham gia các bài kiểm tra trực quan và nhận phản hồi sửa sai tức thời mà không phải chịu áp lực thi cử căng thẳng.

---

## 4.2 Diễn tiến và luồng bài giảng

Hành trình học tập của người học được tổ chức chặt chẽ theo cấu trúc phân bậc tiến trình sư phạm cá nhân hóa từ cơ bản đến nâng cao. Luồng hoạt động tổng thể diễn ra như sau:

1.  **Giai đoạn khởi nhập**: Ngay khi ứng dụng được tải thành công, người học xuất hiện tại khu vực **Hành lang chính** của trung tâm ngoại ngữ ảo. Tại đây, một bảng thông tin hướng dẫn tổng quan sẽ giới thiệu cơ chế bắt khớp tay trần và cách thức di chuyển. Người học không cần thực hiện các cài đặt phức tạp mà có thể lập tức mở khóa phòng học đầu tiên **Alphabets** để bắt đầu trải nghiệm.
2.  **Chu trình học tập trong phòng học chuyên đề**: Trong mỗi phòng học, tiến trình học tập được phân tách thành hai khu vực tương tác rõ ràng:
    - **Giai đoạn Thực hành**: Người học đứng đối diện với giảng viên ảo Kyle. Kyle sẽ đưa ra các thẻ từ vựng ngẫu nhiên, thực hiện động tác mẫu và đợi người học uốn nắn bàn tay làm theo. Khi người học gõ đúng cử chỉ tay trần, hệ thống lập tức báo đúng và Kyle sẽ chuyển sang từ vựng tiếp theo.
    - **Giai đoạn Kiểm tra**: Sau khi thực hành tự tin, người học di chuyển tới bảng thi 3D để làm bài kiểm tra đánh giá tổng hợp gồm các câu hỏi trắc nghiệm cử chỉ, đánh vần chuỗi ký tự hoặc nghe audio điền từ vào chỗ trống.
3.  **Cơ chế đánh giá và mở khóa tiến trình**: Khi hoàn thành toàn bộ câu hỏi trong bài kiểm tra, hệ thống sẽ tính toán điểm số.
    - Nếu điểm số đạt từ **80% trở lên**, người học được công nhận là đã **Master** chủ đề này. Trạng thái của Topic trên cổ tay sẽ đổi sang màu vàng gold, đồng thời hệ thống tự động mở khóa phòng học chuyên đề tiếp theo.
    - Nếu điểm số dưới **80%**, phòng học tiếp theo vẫn sẽ ở trạng thái khóa. Người học được khuyến khích quay lại khu vực thực hành để luyện tập thêm cùng giảng viên ảo Kyle và thực hiện lại bài kiểm tra để cải thiện điểm số.
4.  **Kiểm soát luồng hoạt động**: Người học có thể tự do theo dõi tiến trình tổng thể, xem chi tiết điểm số từng phần hoặc bấm chọn teleport nhanh giữa các phòng học đã mở khóa bằng cách lật ngửa cổ tay từ 60 - 90 độ để kích hoạt **Menu** tại bất kỳ thời điểm nào.

---

## 4.3 Cơ chế của bài giảng

### 4.3.1 Luật tương tác và cơ chế sư phạm

Để đảm bảo bài giảng diễn ra trơn tru, không gây ức chế tâm lý do giới hạn vật lý của cảm biến bắt khớp tay trần trên kính VR, hệ thống tích hợp 3 luật ngầm độc đáo:

- **Cơ chế Sai lầm ẩn**: Cảm biến camera hồng ngoại của kính VR dễ gặp hiện tượng nhiễu bắt khớp ngón tay trong một vài khung hình ngắn. Thay vì lập tức phạt điểm người học khi khớp tay bị lệch nhẹ ngoài ý muốn, hệ thống sử dụng một bộ đệm thời gian ngắn (từ 1.5 - 2 giây). Chỉ khi người học duy trì tư thế tay sai vượt quá thời gian đệm này, hệ thống mới ghi nhận là một lỗi sai thực sự.
- **Cửa sổ vô địch**: Ngay sau khi người học làm sai một cử chỉ và bị hệ thống báo lỗi, một cửa sổ thời gian miễn phạt ngắn (1.0 giây) được kích hoạt. Giai đoạn này cho phép người học thả lỏng cơ tay, thoải mái uốn nắn điều chỉnh lại các khớp ngón tay mà không lo sợ bị hệ thống liên tục phạt điểm dồn dập.
- **Danh sách cử chỉ miễn phạt**: Các cử chỉ tay tự nhiên dùng để tương tác điều khiển giao diện (như lật ngửa cổ tay mở menu hay trỏ ngón tay di chuyển) được hệ thống đăng ký vào danh sách ngoại lệ, đảm bảo không bao giờ bị tính nhầm là lỗi thực hiện sai bài học.

### 4.3.2 Mô hình thế giới học tập ảo

- **Vật lý tương tác**: Không gian phòng học ảo triệt tiêu hoàn toàn trọng lực vật lý đối với các thành phần giao diện. Người học di chuyển bằng cơ chế phóng tia teleport từ cổ tay tới các điểm neo sàn nhà được thiết lập sẵn, giúp triệt tiêu hoàn toàn hiện tượng trễ hình hay say VR.
- **Hệ thống điểm số học thuật**: "Tiền tệ" duy nhất trong không gian học tập là điểm số phần trạng thái chính xác (0 - 100%). Người học tích lũy điểm bằng cách thực hiện đúng cử chỉ yêu cầu ngay trong lần thử đầu tiên của câu hỏi. Điểm số này được lưu trữ bền vững vào hệ thống để làm căn cứ mở khóa các màn học tiếp theo.

### 4.3.3 Các hành động của người học

- **Di chuyển**: Nhắm tia trỏ từ xa và thả tay để dịch chuyển tức thời qua các phòng học chuyên đề.
- **Tương tác bảng điều khiển**: Dùng đầu ngón trỏ vật lý chạm trực tiếp vào các nút bấm 3D lơ lửng trên Quiz Board hoặc lật ngửa cổ tay để đóng/mở menu Bài giảng.
- **Thực hành ký hiệu**: Uốn nắn bàn tay trần trước camera kính VR để tạo ra các hình dạng tay khớp với mẫu, hoặc giữ tư thế nền và di chuyển ngón trỏ trong không gian để vẽ nét chữ `J` và `Z`.

### 4.3.4 Luồng màn hình

Hệ thống chuyển đổi qua các không gian học tập lập thể 3D trực quan bao gồm:
`Hành lang chính` $\rightarrow$ `Phòng học bảng chữ cái` $\rightarrow$ `Phòng học chữ số` $\rightarrow$ `Phòng học giao tiếp`. Mỗi không gian là một scene 3D riêng biệt được tối ưu hóa tài nguyên phần cứng.

### 4.3.5 Phản hồi cho người học

- **Phản hồi màu sắc khớp tay ảo**: Khi người học uốn tay, bộ xương bàn tay ảo trên màn hình sẽ đổi màu sắc thời gian thực: màu xanh dương báo hiệu đúng, màu đỏ cam báo hiệu sai lệch góc khớp, và màu be mặc định báo hiệu trạng thái chờ đợi bắt khớp.
- **Phản hồi âm thanh**: Âm thanh "ting" vui tai khi thực hiện đúng và âm thanh báo lỗi nhẹ nhàng khi thực hiện sai, kết hợp giọng đọc phát âm tiếng Anh trực quan của từ vựng.
- **Phản hồi từ Kyle**: Giảng viên Kyle sẽ vỗ tay chúc mừng khi người học hoàn thành xuất sắc hoặc làm động tác hướng dẫn chậm lại khi người học gặp khó khăn.

---

## 4.4 Điều khiển

Hệ thống điều khiển tay trần tự nhiên ánh xạ trực tiếp các hành động cơ thể vật lý của người học vào không gian ảo 3D:

- **Mở/Đóng Wrist Dashboard**: Xoay ngửa cổ tay một góc từ 60 - 90 độ hướng lên phía mắt kính VR.
- **Nhận dạng chữ cái tĩnh**: Uốn nắn hình dạng tay theo bảng ký tự mẫu ASL.
- **Nhận dạng nét vẽ động (J, Z)**: Giữ bàn tay ở tư thế ra lệnh vẽ, dùng đầu ngón trỏ di chuyển vẽ quỹ đạo trong không gian, hệ thống sẽ kích hoạt thành phần vẽ đường nét sáng neon bám theo tay. Thả tư thế tay để kết thúc và đánh giá nét vẽ.
- **Teleport**: Trỏ ngón tay về phía điểm neo dịch chuyển dưới sàn nhà và bấm nút ảo để di chuyển.

---

## 4.5 Bối cảnh sư phạm và vai trò của người hướng dẫn

Bài giảng được đặt trong bối cảnh một phòng lab ngôn ngữ hiện đại, thoáng đãng và có thiết kế tương lai. Người học không đơn độc tự học qua tài liệu khô khan mà có sự đồng hành của giảng viên ảo Kyle. Kyle đóng vai trò là một người hướng dẫn mẫu mực, không bao giờ mệt mỏi, luôn sẵn sàng lặp lại các tư thế tay phức tạp nhiều lần cho đến khi người học nắm vững, tạo ra một không gian tương tác một-một thân thiện và hiệu quả.

---

## 4.6 Không gian học tập ảo (Thế giới bài giảng)

Môi trường 3D được thiết kế tối giản, sử dụng các gam màu trung tính kết hợp hệ thống ánh sáng dịu nhẹ để ngăn ngừa mỏi mắt cho người học khi đeo kính VR lâu. Không gian bao gồm:

- **Phòng Hành lang chính**: Nơi kết nối các cửa phòng học chuyên đề. Các cửa phòng học sẽ hiển thị trạng thái khóa bằng ổ khóa 3D và tự động mở ra khi người học hoàn thành Master phòng học trước đó.
- **3 Phòng học chuyên đề độc lập**: Mỗi phòng học được thiết kế rộng rãi, có khu vực bục giảng thực hành riêng biệt đứng đối diện Kyle và góc làm bài kiểm tra tĩnh lặng đặt Quiz Board.

---

## 4.7 Người học và giảng viên ảo Kyle

- **Bàn tay ảo của người học**: Được dựng lưới 3D trong suốt hiển thị rõ 26 khớp xương bàn tay ảo khớp chính xác với bàn tay thật, giúp người học dễ dàng tự quan sát và uốn nắn ngón tay mình.
- **Giảng viên ảo Kyle**: Một mô hình nhân vật 3D nam thân thiện, được thiết lập bộ xương tay chi tiết để có thể thực hiện chính xác các chuyển động tinh tế của ngón tay. Bộ điều khiển hoạt ảnh hoạt động theo máy trạng thái hữu hạn (FSM) gồm: `Idle`, `Greeting`, `DemonstratePose`, `CelebrateCorrect`, `EncourageRetry`.

---

## 4.8 Các phòng học chuyên đề (Màn học)

Hệ thống bài học được phân chia thành 3 phòng học tương ứng với 3 chủ đề học tập có độ khó tăng dần:

1.  **Phòng học 1: Bảng chữ cái (ASL Alphabets)**: Master 26 chữ cái đơn tĩnh và 2 chữ cái động nét vẽ (J, Z). Đây là phòng học nền tảng giúp người học làm quen với cơ chế bắt khớp tay trần và vẽ nét không gian ảo.
2.  **Phòng học 2: Chữ số học thuật (ASL Numbers)**: Làm chủ các cử chỉ biểu đạt số từ 0 - 9 và giải các bài toán đố cộng trừ nhân chia trực quan. Sử dụng phương pháp kiểm tra điền trống (Gap-Only) để đánh giá.
3.  **Phòng học 3: Hội thoại giao tiếp (ASL Greetings)**: Học sinh học cách kết hợp cả cử chỉ một tay và hai tay phối hợp đồng bộ để nói các từ giao tiếp như "HELLO", "CLASS", "YOU", "ME". Sử dụng phương pháp kiểm tra chuỗi tuần tự (Full-Sequence).

---

## 4.9 Giao diện người dùng (UI)

Hệ thống giao diện 3D lập thể được thiết kế hướng mục tiêu tối ưu tầm nhìn và giảm thiểu hiện tượng che khuất camera:

- **Wrist Dashboard UI**: Giao diện phẳng 2D được đặt trên Canvas World Space gắn trực tiếp vào xương cổ tay trái/phải. Hệ thống tự động vô hiệu hóa thành phần Layout Group tĩnh ngay sau khi sắp xếp UI xong (`VerticalLayoutGroup.enabled = false`) để loại bỏ việc Unity rebuild UI liên tục mỗi khung hình, đảm bảo FPS tối đa.
  - _Hình 4.3_: Bản phác thảo thiết kế giao diện Wrist Dashboard trên cổ tay người học.
- **Quiz Board**: Bảng giao diện 3D lớn hiển thị câu hỏi kiểm tra, hình ảnh minh họa sắc nét và dòng ô trống đáp án thời gian thực. Các ký tự hiển thị được tăng kích thước lớn từ `<size=180%>` đến `<size=200%>` với màu be chủ đạo tạo cảm giác premium dễ chịu.
  - _Hình 4.4_: Thiết kế giao diện Quiz Board khi thực hiện đánh vần từ.
- **Billboard tự hướng mặt người chơi (UIFaceCamera)**: Các nhãn Canvas lơ lửng hướng dẫn được lập trình tự động xoay quanh trục Y để luôn hướng vuông góc thẳng trực diện về phía Camera kính HMD của người học, giúp thông tin luôn hiển thị rõ ràng ở mọi góc đứng thực hành.

---

## 4.10 Thiết kế kiến trúc kỹ thuật

### 4.10.1 Lựa chọn kiến trúc phần mềm

Để giải quyết triệt để các thách thức về xung đột thứ tự khởi động (Race Condition) và đảm bảo tính cô lập giữa các module tương tác thô của SDK kính VR và logic sư phạm của đồ án, hệ thống sử dụng **Kiến trúc hướng sự kiện (Event-Driven Architecture)** xoay quanh bộ trung chuyển sự kiện tĩnh trung tâm mang tên **`GestureHub.cs`**. `GestureHub` đăng ký các sự kiện toàn cục:

```csharp
public static event Action<string> OnGestureDetected;
public static event Action<string> OnGestureEnded;
```

Bất kỳ khi nào cảm biến bắt khớp tay của Unity XR Hands phát hiện cử chỉ tay trần hợp lệ hoặc nét vẽ của ngón tay hoàn tất, hệ thống sẽ phát đi sự kiện:

```csharp
GestureHub.Publish(gestureID, true);
```

Các lớp quản lý tiến trình (`QuizManager`, `NPCKyleController`) đăng ký lắng nghe sự kiện này để chấm điểm hoặc thực hiện hoạt ảnh tương ứng mà không hề phụ thuộc trực tiếp vào tầng phần cứng.

### 4.10.2 Sơ đồ khối tổng quan

Sơ đồ kết nối thông tin tổng quan của hệ thống tương tác Event-Driven được thể hiện tại hình dưới đây:

- **[Hình 4.1]**: _Sơ đồ khối kiến trúc Event-Driven của hệ thống tương tác ASL VR._

### 4.10.3 Sơ đồ gói (Package Diagram)

Ứng dụng được phân rã thành 3 lớp gói phần mềm rõ rệt để đảm bảo tính dễ bảo trì và khả năng tái sử dụng độc lập:

- **[Hình 4.2]**: _Sơ đồ gói (Package Diagram) phân rã 3 lớp của ứng dụng._
  1.  _Gói Tầng Cảm Biến/Input Layer (`Input & Sensoring Gói`)_: Gồm `XR Origin`, `XR Hand Tracking Events`, các bộ bắt khớp `StaticHandGesture` và `VRMagicTrajectory`.
  2.  _Gói Tầng Điều Khiển/Broker Layer (`Core Control & Broker Gói`)_: Trái tim xử lý dữ liệu gồm bộ trung chuyển sự kiện `GestureHub`, bộ quản lý tiến trình mở khóa `ProgressManager`, bộ chuyển pha phòng học `ClassroomManager`.
  3.  _Gói Tầng Giao Diện/Presentation Layer (`UI & View Presentation Gói`)_: Quản lý giao diện hiển thị 3D gồm bảng thi `Quiz Board` (chứa `QuizManager`), menu cổ tay `WristDashboardUI`, bảng xoay hướng camera `UIFaceCamera` và mô hình hoạt ảnh hướng dẫn `NPC Kyle Controller`.

---

## 4.11 Thiết kế chi tiết lớp và cơ sở dữ liệu

### 4.11.1 Sơ đồ lớp (Class Diagram)

Mối quan hệ kế thừa, tham chiếu và điều phối giữa các thực thể lập trình cốt lõi trong mã nguồn C# được thể hiện qua sơ đồ lớp chi tiết:

- **[Hình 4.5]**: _Sơ đồ lớp (Class Diagram) chi tiết của toàn bộ hệ thống lớp ASL VR._

### 4.11.2 Đặc tả cấu trúc Scriptable Object

Hệ thống sử dụng các file tài sản độc lập **Scriptable Object** (.asset) để lưu trữ cấu trúc câu hỏi thi và bài thực hành, giúp tách biệt hoàn toàn dữ liệu học tập ra khỏi mã nguồn logic.

#### Bảng 4.1: Đặc tả cấu trúc thuộc tính của Scriptable Object `QuizData` (.asset)

| Tên biến thuộc tính   | Kiểu dữ liệu          | Ý nghĩa chức năng cấu hình                                                                                            |
| --------------------- | --------------------- | --------------------------------------------------------------------------------------------------------------------- |
| **questionType**      | Enum (`QuestionType`) | Dạng câu hỏi: `Matching` (So khớp ảnh), `Ordering` (Đánh vần chuỗi), hoặc `AudioFillInTheGap` (Nghe audio điền trống) |
| **questionText**      | String (`[TextArea]`) | Văn bản câu hỏi hiển thị trên bảng thi Quiz Board                                                                     |
| **sentenceTemplate**  | String                | Mẫu câu điền trống (Ví dụ: "I love \_" hoặc "I love {0}")                                                             |
| **questionImage**     | Sprite                | Hình ảnh mô tả cử chỉ tay mẫu hoặc hình ảnh minh họa từ khóa                                                          |
| **questionAudio**     | AudioClip             | Tệp tin âm thanh phát âm từ vựng tương ứng                                                                            |
| **topic**             | String                | Tên Topic phân loại (Alphabets, Numbers, Greetings)                                                                   |
| **correctGestureIDs** | Array of String       | Mảng chuỗi các cử chỉ đúng cần gõ (Ví dụ: `["C", "A", "T"]` cho từ CAT)                                               |

#### Bảng 4.2: Đặc tả cấu trúc thuộc tính của Scriptable Object `PracticeData` (.asset)

| Tên biến thuộc tính | Kiểu dữ liệu   | Ý nghĩa chức năng cấu hình                                                        |
| ------------------- | -------------- | --------------------------------------------------------------------------------- |
| **targetWord**      | String         | Từ vựng cần học thực hành hướng dẫn (Ví dụ: "HELLO" hoặc "CLASS")                 |
| **gestureSequence** | List of String | Chuỗi các cử chỉ tương ứng cấu thành từ vựng (Ví dụ: `["H", "E", "L", "L", "O"]`) |

---

## 4.12 Triển khai hệ thống

### 4.12.1 Công cụ và thư viện phát triển

- **Công cụ phát triển**: Unity Engine 2022.3.15f1 LTS làm nền tảng phát triển chính. Visual Studio 2022 làm môi trường viết mã C#.
- **Gói thư viện tích hợp**:
  - Gói `Unity XR Hands 1.4.1` cung cấp API bắt 26 khớp xương bàn tay vật lý.
  - Gói `OpenXR Plugin 1.10.0` đảm bảo khả năng tương thích phần cứng đa nền tảng với các thiết bị Quest.
  - Gói `TextMeshPro 3.0.6` hiển thị văn bản 3D sắc nét trong môi trường VR.

### 4.12.2 Tối ưu hóa hiệu suất đồ họa Standalone

Do vi xử lý di động tích hợp trên kính Meta Quest 2 standalone có tài nguyên phần cứng giới hạn, đồ án bắt buộc phải triển khai 3 giải pháp tối ưu hóa hiệu năng đồ họa nghiêm ngặt:

1.  **Single Pass Instanced Rendering**: Kỹ thuật dựng hình kết xuất cho cả hai mắt của người dùng cùng một lúc trong một lượt vẽ duy nhất (draw call), giúp tiết kiệm **50%** tài nguyên xử lý CPU và loại bỏ hoàn toàn hiện tượng nghẽn cổ châu CPU.
2.  **Nướng ánh sáng tĩnh (Lightmapping)**: Tắt hoàn toàn bóng đổ động (Dynamic Shadows) của các nguồn sáng trong phòng học, thực hiện nướng trước toàn bộ ánh sáng và bóng đổ vào bản đồ ánh sáng tĩnh để tiết kiệm năng lượng tính toán của GPU.
3.  **Giới hạn kích thước bộ nhớ Texture**: Giới hạn toàn bộ Texture hình ảnh câu hỏi và UI ở mức tối đa **1024x1024 px** để tiết kiệm tối đa bộ nhớ VRAM của kính VR.
    Nhờ các giải pháp tối ưu hóa này, bài giảng chạy cực kỳ mượt mà, đạt mức khung hình ổn định **80 - 90 FPS** liên tục, đảm bảo người dùng học tập thoải mái trong nhiều giờ mà không bị chóng mặt hay say VR.

---

## 4.13 Kiểm thử hệ thống (System Testing)

Đồ án đã tiến hành thử nghiệm kiểm thử thực tế (Black-box testing) trên nhóm mẫu gồm **15 người dùng** sử dụng kính Meta Quest 2 ở các điều kiện ánh sáng phòng học khác nhau để đo lường độ chính xác và khả năng thích ứng của hệ thống bắt khớp tay trần tự nhiên.

#### Bảng 4.3: Thống kê độ chính xác nhận diện cử chỉ tay (Static & Dynamic) qua kiểm thử thực tế

| Nhóm cử chỉ tay                            | Số lần kiểm thử | Nhận diện đúng | Nhận diện sai / Bị mất dấu | Tỉ lệ chính xác (%) |
| ------------------------------------------ | --------------- | -------------- | -------------------------- | ------------------- |
| **Ký tự tĩnh dễ (A, B, C, D, L, W, Y...)** | 300             | 288            | 12                         | **96.0%**           |
| **Ký tự tĩnh khó nắm (M, N, T, S, E)**     | 200             | 176            | 24                         | **88.0%**           |
| **Cử chỉ Hai tay (Greetings, Me, You...)** | 150             | 134            | 16                         | **89.3%**           |
| **Nét vẽ quỹ đạo động (J, Z)**             | 150             | 131            | 19                         | **87.3%**           |
| **Chỉ số chung toàn bộ hệ thống**          | **800**         | **729**        | **71**                     | **91.1%**           |

_Nhận xét kết quả_: Tỉ lệ nhận dạng chung của hệ thống đạt mức cực kỳ ấn tượng là **91.1%**. Các lỗi sai chủ yếu xuất hiện ở nhóm ký tự nắm đấm khó phân biệt góc khớp ngón tay (`M`, `N`, `T`) hoặc nét vẽ động khi người học di chuyển ngón trỏ quá nhanh hay đưa ngón tay ra ngoài vùng camera theo dõi của kính VR. Tuy nhiên, nhờ cơ chế **AreEquivalent** gộp các ký tự dễ nhầm lẫn thành nhóm tương đương và cơ chế đệm sai lầm ẩn **Hidden Mistakes**, quá trình học tập thực hành của người học vẫn diễn ra cực kỳ mượt mà, tự nhiên và không hề bị gián đoạn hay gây cảm giác ức chế cho người học.

---

## Minh họa hình ảnh thực nghiệm chức năng bài giảng:

- **[Hình 4.6]**: _Ảnh chụp màn hình NPC Kyle hướng dẫn thực hành cử chỉ trực quan._
- **[Hình 4.7]**: _Ảnh chụp màn hình phản hồi màu sắc cử chỉ tĩnh (Green = Đúng, Red = Sai)._
- **[Hình 4.8]**: _Ảnh chụp màn hình vẽ quỹ đạo chữ J/Z thông qua LineRenderer trong VR._
- **[Hình 4.9]**: _Ảnh chụp màn hình Bảng điều khiển cổ tay cập nhật điểm số thực tế._
