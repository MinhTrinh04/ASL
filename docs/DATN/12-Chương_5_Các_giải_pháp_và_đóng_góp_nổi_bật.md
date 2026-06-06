# CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ

## 5.1 Thiết kế kiến trúc

### 5.1.1 Lựa chọn kiến trúc phần mềm

Hệ thống bài giảng tương tác Ngôn ngữ ký hiệu Mỹ trong Thực tế ảo (ASL VR) được xây dựng dựa trên mô hình Kiến trúc dựa trên thành phần (Component-Based Architecture), một phương pháp tiếp cận phổ biến và được hỗ trợ tự nhiên bởi môi trường phát triển Unity Engine. Nguyên tắc cốt lõi của kiến trúc này là xây dựng các đối tượng (GameObjects) bằng cách tổng hợp từ nhiều thành phần độc lập (Components), mỗi thành phần đóng gói một logic hoặc tập dữ liệu cụ thể. Để tách biệt rõ ràng giữa xử lý logic nghiệp vụ và giao diện trình diễn, đồng thời tối ưu hóa tính năng tương tác hand tracking, hệ thống được tinh chỉnh và phân chia thành bốn lớp logic chính hoạt động độc lập nhằm phân tách các mối quan tâm khác nhau.

Lớp Dữ liệu Học thuật (Academic Data Layer) chịu trách nhiệm lưu trữ và định nghĩa toàn bộ nội dung giáo trình, bao gồm danh sách từ vựng ký hiệu và hệ thống câu hỏi kiểm tra dưới dạng dữ liệu tĩnh. Ý nghĩa cốt lõi của lớp này là tách rời hoàn toàn phần nội dung bài học ra khỏi logic lập trình. Điều này giúp cho việc cập nhật, bổ sung học liệu hoặc mở rộng thêm các bài giảng mới trong tương lai có thể thực hiện một cách nhanh chóng và linh hoạt trực tiếp trên môi trường Unity mà không cần phải can thiệp hay thay đổi mã nguồn của ứng dụng.

Lớp Thu thập và Nhận dạng Cử chỉ (Gesture Capture & Recognition Layer) đóng vai trò thu nhận chuyển động của xương bàn tay từ cảm biến camera của thiết bị thực tế ảo và thực hiện nhận dạng các cử chỉ tay tĩnh hoặc động trong không gian. Ý nghĩa của lớp này là chuyển đổi các hành động vật lý tự nhiên của người học thành các tín hiệu cử chỉ có cấu trúc. Lớp này đóng gói toàn bộ các thuật toán xử lý khớp xương và quỹ đạo chuyển động phức tạp, cung cấp dữ liệu nhận diện đồng nhất và ổn định để các lớp logic cấp cao hơn có thể hiểu và xử lý.

Lớp Điều khiển và Quản lý Tiến trình (Control & Progression Layer) đóng vai trò là bộ não điều hành toàn bộ logic sư phạm, lưu trữ kết quả và điều phối trạng thái của phòng học ảo. Ý nghĩa của lớp này là quản lý vòng đời của bài học, kiểm tra điều kiện mở khóa bài mới dựa trên kết quả tự học, và vận hành cơ chế thi cử với các quy tắc sư phạm hỗ trợ. Lớp này giúp kết nối dữ liệu tĩnh của bài học với các phản hồi sư phạm thực tế, tạo ra một lộ trình học tập có cấu trúc và có tính tương tác cao cho người học.

Lớp Trình diễn và Tương tác (Presentation & Interaction Layer) chịu trách nhiệm hiển thị giao diện đồ họa trực quan, các phản hồi hình ảnh thời gian thực và xử lý di chuyển thực tế ảo. Ý nghĩa của lớp này là tối ưu hóa trải nghiệm tương tác trực quan của người học trong không gian ba chiều, giúp hiển thị tiến trình học trên cổ tay, thể hiện các hoạt ảnh hướng dẫn sinh động của giảng viên ảo, và cung cấp cơ chế di chuyển tự nhiên bằng cử chỉ tay trần để tăng cường tính chân thực và sự tập trung.

---

### 5.1.2 Thiết kế tổng quan

Biểu đồ gói dưới đây mô tả kiến trúc tổng quan của ứng dụng ASL VR, được phân chia thành các gói (package) logic và gom nhóm theo vai trò lõi hoặc ngoại vi của hệ thống bài giảng:

```mermaid
graph TD
    %% Gói bên ngoài
    PresentationInteraction[Presentation & Interaction / Gói trình diễn và tương tác]
    AcademicData[AcademicData / Gói dữ liệu học thuật]

    %% Gói Lõi bài giảng ở giữa
    subgraph Core [Core / Lõi bài giảng]
        Progression[Progression / Gói quản lý tiến trình]
        GestureCaptureRecognition[Gesture Capture & Recognition / Gói thu nhận và nhận dạng cử chỉ]

        Progression --> GestureCaptureRecognition
    end

    %% Mối quan hệ phụ thuộc
    PresentationInteraction --> Progression
    PresentationInteraction --> GestureCaptureRecognition
    Progression --> AcademicData
    GestureCaptureRecognition --> AcademicData

    style PresentationInteraction fill:#fff,stroke:#333,stroke-width:1px;
    style Core fill:#fff,stroke:#333,stroke-width:1px,stroke-dasharray: 5 5;
```

### 5.1.3 Thiết kế chi tiết gói

Biểu đồ thiết kế chi tiết các lớp cốt lõi và mối quan hệ tương tác của từng gói lập trình chính trong hệ thống được trình bày cụ thể dưới đây:

#### a, Gói Progression (Quản lý tiến trình)

> **Hình 5.2:** _Thiết kế chi tiết của Gói Progression (Quản lý tiến trình)_

```mermaid
%%{init: {'theme': 'neutral'}}%%
classDiagram
    namespace Progression_Package {
        class ProgressManager
        class ClassroomManager
        class GestureTopicController
        class QuizManager
        class NPCKyleController
        class NPCLobbyInstructorController
    }
    class GestureHub
    class WristDashboardUI

    ProgressManager "1" o-- "many" ClassroomManager : quản lý
    ProgressManager "1" --> "1" GestureTopicController : điều phối
    ClassroomManager "1" --> "1" GestureTopicController : lấy spawn point
    ClassroomManager "1" o-- "many" QuizManager : chứa bảng thi
    ClassroomManager "1" --> "1" NPCKyleController : điều khiển
    NPCKyleController ..> ClassroomManager : kích hoạt thi

    QuizManager ..> GestureHub : lắng nghe cử chỉ
    WristDashboardUI ..> ProgressManager : đọc điểm số
```

Đây là gói quan trọng nhất giúp điều hành tiến trình học tập của người học và quản lý toàn bộ các phòng học ảo cùng hệ thống thi trắc nghiệm và các nhân vật hướng dẫn ảo. Lớp ProgressManager giữ vai trò trung tâm, quản lý trạng thái tổng thể của tiến trình học tập, lưu trữ điểm số cao nhất của người học thông qua PlayerPrefs và điều phối việc mở khóa chủ đề tiếp theo dựa trên điểm đạt được.

Lớp ClassroomManager chịu trách nhiệm quản lý vòng đời và các giai đoạn học tập của mỗi phòng học ảo chuyên đề cụ thể, bao gồm việc chuyển đổi giữa giai đoạn học lý thuyết (Lecture Phase) và giai đoạn thi trắc nghiệm (Quiz Phase). Lớp GestureTopicController điều khiển việc bật tắt các nhóm cử chỉ nhận diện tĩnh theo từng chủ đề học tập để đảm bảo tối ưu hiệu năng và độ chính xác của hệ thống nhận diện.

Lớp QuizManager điều phối toàn bộ quá trình thi cử của phòng học ảo, nạp danh sách câu hỏi kiểm tra, tiếp nhận các sự kiện cử chỉ đáp án của người học thông qua bộ trung chuyển sự kiện GestureHub để thực hiện chấm điểm tự động và áp dụng các cơ chế trò chơi hóa như cửa sổ vô địch và lượt phạt.

Các nhân vật hướng dẫn ảo đóng vai trò hỗ trợ đắc lực và là một phần không thể tách rời của ClassroomManager. Lớp NPCKyleController điều khiển giảng viên ảo Kyle thực hiện các hoạt ảnh vẫy tay chào khi người học bước vào phòng học, suy nghĩ khi người học thực hành và vỗ tay khích lệ khi hoàn thành bài học. Lớp NPCLobbyInstructorController điều khiển nhân vật hướng dẫn tại sảnh hành lang để chào đón và đưa ra lời giới thiệu ban đầu cho người học.

#### b, Gói Gesture Recognition (Nhận dạng cử chỉ)

> **Hình 5.3:** _Thiết kế chi tiết của Gói Gesture Recognition (Nhận dạng cử chỉ)_

```mermaid
%%{init: {'theme': 'neutral'}}%%
classDiagram
    namespace Gesture_Recognition_Package {
        class GestureHub
        class GestureLesson
        class VRMagicTrajectory
        class VRMagicUnistroke
        class GestureTrigger
        class GestureLocomotionProvider
    }

    GestureLesson ..> GestureHub : lắng nghe sự kiện
    VRMagicTrajectory ..> GestureHub : xuất bản sự kiện
    VRMagicTrajectory ..> VRMagicUnistroke : sử dụng giải thuật
    GestureTrigger ..> GestureHub : xuất bản sự kiện
    GestureLocomotionProvider ..> GestureHub : lắng nghe sự kiện di chuyển
```

Đây là gói nền tảng chịu trách nhiệm thu nhận dữ liệu khớp xương tay, thực hiện nhận dạng các cử chỉ tĩnh, động và điều khiển di chuyển bằng tay trần của người học. Lớp GestureHub giữ vai trò trung tâm hoạt động như một bộ trung chuyển sự kiện, cung cấp sự kiện tĩnh OnGestureDetected để tất cả các thành phần khác có thể đăng ký lắng nghe và phản hồi khi có cử chỉ tương ứng.

Lớp GestureLesson lắng nghe các cử chỉ học tập cụ thể để kiểm tra thời gian giữ đúng tư thế (Hold Time) và cập nhật vòng tiến trình thời gian thực. Lớp VRMagicTrajectory chịu trách nhiệm thu nhận chuyển động ngón trỏ để vẽ nét và nhận diện cử chỉ động cho chữ J và Z.

Lớp VRMagicUnistroke cung cấp thuật toán nhận diện nét vẽ 2D Unistroke, tính toán điểm số khớp mẫu so với các quỹ đạo mẫu được lưu trữ. Lớp GestureTrigger cho phép kích hoạt các sự kiện cử chỉ khi bàn tay người học tương tác vật lý với các vùng không gian xác định. Lớp GestureLocomotionProvider chịu trách nhiệm di chuyển người học trong không gian ảo bằng cách lắng nghe các tín hiệu cử chỉ chỉ tay từ GestureHub thay vì trực tiếp truy cập và kiểm tra các khớp tay từ SDK để kích hoạt di chuyển mượt mà (Smooth Locomotion).

---

## 5.2 Thiết kế chi tiết

### 5.2.1 Thiết kế lớp

Để làm rõ phương thức hoạt động và tương tác giữa các thực thể phần mềm trong bài giảng ASL VR, mục này trình bày chi tiết các thuộc tính và phương thức xử lý chính của ba lớp chủ đạo trong hệ thống, bao gồm QuizManager, VRMagicTrajectory và ProgressManager.

#### a, Lớp QuizManager

Lớp này chịu trách nhiệm điều phối toàn bộ quá trình thi cử của mỗi phòng học ảo, xử lý logic kiểm tra cử chỉ, cập nhật điểm số và áp dụng các cơ chế trò chơi hóa để giảm áp lực phòng thi cho học viên.

- **Các thuộc tính quan trọng:**
  - questionTextUI: Thành phần TMP_Text hiển thị nội dung câu hỏi hiện tại lên bảng thi 3D.
  - questionImageUI: Thành phần Image hiển thị hình ảnh ký hiệu hoặc sơ đồ gợi ý tương ứng.
  - feedbackTextUI: Thành phần TMP_Text hiển thị các phản hồi trực quan thời gian thực (như đúng, sai hoặc số lượt làm sai còn lại).
  - scoreTextUI: Thành phần TMP_Text hiển thị điểm số tích lũy của học viên.
  - questionList: Danh sách chứa các đối tượng câu hỏi QuizData nạp vào từ ScriptableObject.
  - currentQuestionIndex: Chỉ số nguyên đại diện cho câu hỏi hiện tại đang xử lý.
  - score: Giá trị thực lưu trữ điểm số tích lũy của người học trong bài thi hiện tại.
  - currentInputBuffer: Bộ đệm danh sách chuỗi ký tự chứa các cử chỉ đã nhập đúng của câu hỏi hiện tại (phục vụ cho chế độ đánh vần).
  - currentQuestionMistakes: Số lỗi phạt chính thức học viên đã mắc phải ở câu hỏi hiện tại (tối đa là 3 lỗi).
  - hiddenMistakes: Số lỗi gõ sai ẩn tích lũy (3 lỗi ẩn quy đổi thành 1 lỗi phạt chính thức).
  - invincibilityEndTime: Thời điểm kết thúc cửa sổ vô địch (sau khi mắc lỗi phạt đầu tiên, người học có 2.5 giây miễn phạt).
- **Các phương thức chính:**
  - StartExam(): Khởi động bài thi, reset điểm số và nạp câu hỏi đầu tiên.
  - LoadQuestion(index: int): Tải dữ liệu câu hỏi từ danh sách theo chỉ số chỉ định, xóa bộ đệm nhập liệu và cập nhật giao diện hiển thị câu hỏi.
  - SubmitAnswer(gestureID: string): Phương thức lắng nghe sự kiện từ GestureHub. Tiếp nhận cử chỉ tay của người học, kiểm tra điều kiện thời gian trễ giữa các ký tự, so sánh với đáp án mong muốn để quyết định xử lý đúng hoặc sai.
  - HandleCorrectPart(gestureID: string): Xử lý khi học viên thực hiện đúng một ký tự hoặc từ mục tiêu. Cập nhật bộ đệm, tính toán điểm số cộng thêm và kiểm tra xem đã hoàn thành toàn bộ câu hỏi chưa.
  - HandleWrongInput(expected: string, gestureID: string): Xử lý khi học viên thực hiện sai cử chỉ. Phương thức kiểm tra danh sách miễn phạt noPenaltyGestures và trạng thái cửa sổ vô địch. Nếu không thỏa mãn, tăng chỉ số lỗi ẩn. Khi lỗi ẩn đạt ngưỡng 3, tăng số lỗi phạt chính thức và kích hoạt cửa sổ vô địch.
  - HandleDelete(): Cho phép học viên xóa cử chỉ vừa nhập sai trong chuỗi đánh vần để nhập lại.
  - EndExam(): Kết thúc bài thi, tính toán phần trăm điểm đạt được, gửi kết quả về ProgressManager để lưu trữ và kích hoạt thông báo hoàn thành chủ đề.

#### b, Lớp VRMagicTrajectory

Lớp này chịu trách nhiệm thu nhận tọa độ chuyển động của ngón trỏ để vẽ nét trên không gian, chiếu tọa độ và kích hoạt thuật toán nhận diện cử chỉ động cho chữ J và Z.

- **Các thuộc tính quan trọng:**
  - gestureID: Chuỗi định danh chữ cái động cần nhận diện (J hoặc Z).
  - baseHandShape: Đối tượng XRHandShape cấu hình tư thế bàn tay trần chuẩn để kích hoạt trạng thái vẽ (ngón trỏ duỗi thẳng, các ngón khác nắm lại).
  - matchThreshold: Ngưỡng điểm số tối thiểu để công nhận nét vẽ khớp với mẫu (mặc định 0.3).
  - lineRenderer: Thành phần vẽ nét LineRenderer hiển thị quỹ đạo vẽ trực quan trong không gian 3D.
  - playerCamera: Transform tham chiếu camera của người học để làm mốc chiếu tọa độ.
  - worldPoints: Danh sách lưu trữ chuỗi các tọa độ 3D thu được từ đầu ngón trỏ trong không gian thế giới.
  - isDrawing: Trạng thái Boolean xác định người học có đang thực hiện thao tác vẽ nét hay không.
- **Các phương thức chính:**
  - OnJointsUpdated(args: XRHandJointsUpdatedEventArgs): Lắng nghe sự kiện cập nhật vị trí khớp xương tay từ camera của thiết bị thực tế ảo. Kiểm tra xem tư thế bàn tay người học có khớp với baseHandShape hay không để bắt đầu hoặc kết thúc vẽ nét.
  - StartDrawing(): Khởi động trạng thái vẽ nét, dọn dẹp danh sách tọa độ cũ và bật hiển thị LineRenderer.
  - RecordPoint(args: XRHandJointsUpdatedEventArgs): Truy xuất tọa độ đầu ngón trỏ IndexTip. Nếu khoảng cách dịch chuyển so với điểm liền trước vượt quá ngưỡng tối thiểu pointDistanceMin (1cm), ghi nhận tọa độ này vào worldPoints và cập nhật hiển thị nét vẽ.
  - StopDrawingAndEvaluate(): Dừng trạng thái vẽ nét. Chuyển đổi toàn bộ tọa độ thế giới 3D trong worldPoints thành tọa độ 2D trên mặt phẳng song song trước mắt camera camera-local space thông qua InverseTransformPoint, sau đó gửi danh sách điểm 2D này sang lớp VRMagicUnistroke để tính toán điểm số khớp mẫu. Nếu điểm số vượt quá matchThreshold, gọi GestureHub.Publish để phát đi sự kiện phát hiện thành công chữ cái động.
  - ClearTrail(): Tắt hiển thị nét vẽ và reset số điểm vẽ về không.

#### c, Lớp ProgressManager

Lớp quản lý đơn thể điều phối tiến trình mở khóa bài học và dịch chuyển người chơi giữa các không gian.

- **Các thuộc tính quan trọng:**
  - Instance: Thực thể đơn thể duy nhất để truy cập toàn cục.
  - classrooms: Danh sách các ClassroomManager quản lý trạng thái của từng phòng học chuyên đề tương ứng.
  - gestureTopicController: Lớp điều khiển bật tắt các nhóm cử chỉ nhận diện tĩnh theo từng chủ đề.
  - passingGrade: Điểm số tối thiểu để được công nhận Master và mở khóa chủ đề tiếp theo (mặc định 80%).
  - lobbySpawnPoint: Vị trí dịch chuyển xuất phát tại Sảnh hành lang chính.
- **Các phương thức chính:**
  - EnterLobby(): Tắt tất cả các phòng học ảo và nhóm cử chỉ nhận diện chuyên đề, chỉ bật nhóm cử chỉ mặc định của sảnh và dịch chuyển người học về sảnh chính.
  - SaveTopicScore(topicIndex: int, percentage: float): Lưu trữ điểm số thi cao nhất của học viên ở chủ đề tương ứng vào bộ nhớ PlayerPrefs của thiết bị.
  - IsTopicUnlocked(topicIndex: int): Kiểm tra xem chủ đề hiện tại có được mở khóa hay không bằng cách truy vấn điểm số cao nhất của chủ đề liền trước từ PlayerPrefs và so sánh với passingGrade.
  - ApplyTopicChange(newTopicIndex: int): Thực hiện chuyển đổi phòng học ảo. Phương thức kiểm tra điều kiện mở khóa thông qua IsTopicUnlocked, tắt nhóm cử chỉ cũ, kích hoạt nhóm cử chỉ chuyên đề mới, kích hoạt GameObject của phòng học tương ứng và đưa phòng học vào Lecture Mode.

---

#### d, Sơ đồ hoạt động truyền thông điệp (Sequence Diagrams)

Để minh họa luồng xử lý thông điệp thời gian thực giữa các lớp đối tượng, dưới đây là biểu đồ trình tự của ba Use Case cốt lõi trong hệ thống:

##### Use Case 1: Học viên thực hiện bài kiểm tra và trả lời câu hỏi tĩnh

Biểu đồ mô tả quy trình khi người học thực hiện uốn nắn bàn tay trần để trả lời một câu hỏi nhận diện tư thế tay tĩnh trên bảng thi:

```mermaid
sequenceDiagram
    autonumber
    actor Player as Người học
    participant SR as Static Hand Shape Matcher
    participant GH as GestureHub
    participant QM as QuizManager
    participant PM as ProgressManager
    participant UI as UI Bảng kiểm tra

    Player->>SR: Thực hiện uốn nắn bàn tay trần
    Note over SR: So khớp góc khớp xương tay vật lý<br/>với mẫu tư thế tĩnh
    SR->>GH: Publish(gestureID, true)
    GH->>QM: Sự kiện OnGestureDetected(gestureID)

    Note over QM: So sánh với correctGestureIDs[nextIndex]
    alt Nhập đúng cử chỉ mẫu
        QM->>QM: HandleCorrectPart()
        QM->>QM: Tăng điểm số score
        QM->>UI: Cập nhật ScoreTextUI (Màu xanh dương)
        alt Hoàn thành tất cả các ký tự của câu hỏi
            QM->>QM: HandleQuestionComplete()
            QM->>UI: Hiển thị thông báo "PERFECT!"
            QM->>QM: Đợi 2.0 giây (interQuestionDelay)
            QM->>QM: LoadQuestion(nextIndex)
        end
    else Nhập sai cử chỉ mẫu
        QM->>QM: HandleWrongInput()
        Note over QM: Kiểm tra invincibility và noPenalty
        alt Không được miễn phạt và hết 3 lỗi ẩn
            QM->>QM: Tăng currentQuestionMistakes
            QM->>QM: Kích hoạt cửa sổ vô địch (2.5 giây)
            QM->>UI: Hiển thị "Try again! (Attempts left)"
        end
    end
```

##### Use Case 2: Học viên thực hành uốn tay trong chế độ học lý thuyết

Biểu đồ mô tả quy trình giữ tư thế tay theo hướng dẫn của giảng viên Kyle để hoàn thành một bài học thực hành:

```mermaid
sequenceDiagram
    autonumber
    actor Player as Người học
    participant SR as Static Hand Shape Matcher
    participant GH as GestureHub
    participant GL as GestureLesson
    participant Ring as LineRenderer (Vòng tiến trình)

    Player->>SR: Thực hiện uốn tay theo giảng viên Kyle
    SR->>GH: Publish(targetGestureID, true)
    GH->>GL: Sự kiện OnGestureDetected(targetGestureID)
    GL->>GL: SetGestureDetected(true)

    loop Cập nhật mỗi khung hình (Update)
        GL->>GL: currentHoldTime += Time.deltaTime
        GL->>Ring: Cập nhật fillAmount = ratio (HoldTime/RequiredTime)
    end

    Note over GL: Giữ đúng tư thế đủ 1.5 giây
    GL->>GL: HandleLessonCompletion()
    GL->>Ring: fillAmount = 1.0 (Hiển thị màu xanh lá)
    GL->>GL: Phát sự kiện OnLessonFinished
    GL->>GL: Chờ 1.5 giây (resetDelayTime)
    GL->>GL: ResetLesson() & ResetUI()
```

##### Use Case 3: Người học thực hiện vẽ chữ cái động J hoặc Z trên không gian

Biểu đồ mô tả quy trình thu thập tọa độ ngón trỏ, chiếu lên mặt phẳng camera và chạy giải thuật so khớp quỹ đạo nét vẽ:

```mermaid
sequenceDiagram
    autonumber
    actor Player as Người học
    participant VT as VRMagicTrajectory
    participant VU as VRMagicUnistroke
    participant GH as GestureHub
    participant QM as QuizManager

    Player->>VT: Giữ tư thế tay nền chuẩn (baseHandShape)
    Note over VT: Bắt đầu trạng thái vẽ nét (isDrawing = true)
    loop Di chuyển ngón trỏ vẽ nét trong không gian
        Player->>VT: Dịch chuyển đầu ngón trỏ IndexTip
        VT->>VT: Ghi nhận tọa độ 3D và hiển thị LineRenderer
    end
    Player->>VT: Thả bàn tay trần (không khớp baseHandShape)
    Note over VT: Kết thúc vẽ nét (isDrawing = false)
    VT->>VT: StopDrawingAndEvaluate()
    VT->>VT: Chiếu tọa độ thế giới 3D sang 2D cục bộ của Camera
    VT->>VU: Recognize(points2D, template)
    Note over VU: Chuẩn hóa nét vẽ (Normalize)<br/>và chạy tìm kiếm tỷ lệ vàng
    VU-->>VT: Trả về điểm số khớp mẫu score
    alt score >= matchThreshold (Nhận diện thành công)
        VT->>GH: Publish(gestureID, true)
        GH->>QM: Sự kiện OnGestureDetected(gestureID)
        QM->>QM: SubmitAnswer(gestureID)
        VT->>VT: Chờ 1.0 giây rồi ClearTrail()
    else score < matchThreshold (Thất bại)
        VT->>VT: ClearTrail() ngay lập tức
    end
```

---

### 5.2.2 Thiết kế cơ sở dữ liệu

Vì hệ thống bài giảng tương tác ASL VR được thiết kế để vận hành độc lập trực tiếp trên thiết bị kính Meta Quest 2 mà không yêu cầu kết nối mạng liên tục, cơ sở dữ liệu của hệ thống được tối giản hóa tối đa nhằm tối ưu hiệu năng và độ trễ truy cập dữ liệu. Hệ thống sử dụng PlayerPrefs – cơ chế lưu trữ dữ liệu dạng khóa-giá trị (Key-Value) nội bộ của Unity – để lưu trữ và quản lý điểm số tiến trình của người học một cách an toàn và bền vững.

#### a, Thiết kế bảng dữ liệu lưu trữ

Cấu trúc lưu trữ dữ liệu điểm số các chủ đề học tập được đặc tả qua bảng sơ đồ thuộc tính dưới đây:

| Tên Khóa (Key Name) | Kiểu dữ liệu | Giá trị hợp lệ | Ý nghĩa / Giải thích                                                                                |
| :------------------ | :----------: | :------------: | :-------------------------------------------------------------------------------------------------- |
| **Topic_0_Score**   |    float     |  0.0 - 100.0   | Điểm số phần trăm cao nhất đạt được tại phòng thi chủ đề Bảng chữ cái (Alphabets). Mặc định bằng 0. |
| **Topic_1_Score**   |    float     |  0.0 - 100.0   | Điểm số phần trăm cao nhất đạt được tại phòng thi chủ đề Chữ số (Numbers). Mặc định bằng 0.         |
| **Topic_2_Score**   |    float     |  0.0 - 100.0   | Điểm số phần trăm cao nhất đạt được tại phòng thi chủ đề Hội thoại (Greetings). Mặc định bằng 0.    |

> **Bảng 5.1:** _Đặc tả cấu trúc khóa lưu trữ dữ liệu tiến trình học tập_

#### b, Logic đồng bộ hóa và mở khóa chủ đề

Sơ đồ ánh xạ logic dưới đây mô tả cách lớp ProgressManager truy vấn cơ sở dữ liệu nội bộ để xác định điều kiện mở khóa phòng học mới:

```mermaid
graph LR
    subgraph Storage [Thiết bị lưu trữ nội bộ]
        db[(PlayerPrefs Key-Value)]
    end

    subgraph Manager [Lớp ProgressManager]
        check{IsTopicUnlocked?}
        score[GetHighestScore(topicIndex - 1)]
        pass[passingGrade = 80%]
    end

    subgraph TargetRoom [Phòng học mục tiêu]
        action[ApplyTopicChange]
        unlocked((Bật cửa phòng học & Dịch chuyển))
        locked((Cửa đóng & Báo lỗi khóa))
    end

    db -->|Đọc khóa Topic_X_Score| score
    score --> check
    pass --> check
    check -->|Điểm số >= 80%| unlocked
    check -->|Điểm số < 80%| locked
    unlocked --> action
```

Mỗi khi người học hoàn thành bài thi tại QuizManager, điểm số phần trăm mới sẽ được so sánh với giá trị tốt nhất hiện tại. Nếu điểm số mới cao hơn, phương thức SaveTopicScore sẽ thực hiện lưu đè giá trị mới vào PlayerPrefs và gọi hàm Save để ghi nhận vĩnh viễn vào bộ nhớ flash của kính VR, đảm bảo tiến trình tự học của người học không bị mất khi tắt ứng dụng hoặc khởi động lại thiết bị.

---

## 5.3 Xây dựng ứng dụng

### 5.3.1 Thư viện và công cụ sử dụng

Dưới đây là danh sách chi tiết các công cụ phần mềm, ngôn ngữ lập trình, bộ phát triển phần mềm (Software Development Kit - SDK) và thư viện liên kết được sử dụng xuyên suốt quá trình xây dựng bài giảng tương tác ASL VR:

| Mục đích                     | Công cụ / Thư viện     | Phiên bản   | Địa chỉ URL                                                |
| :--------------------------- | :--------------------- | :---------- | :--------------------------------------------------------- |
| **Môi trường phát triển**    | Unity Editor           | 2022.3.50f1 | unity.com                                                  |
| **Trình soạn thảo mã nguồn** | Visual Studio Code     | 1.85        | code.visualstudio.com                                      |
| **Giao tiếp kính VR**        | OpenXR Plugin          | 1.10.0      | docs.unity3d.com/Packages/com.unity.xr.openxr              |
| **Theo dõi bàn tay**         | Unity XR Hands         | 1.4.3       | docs.unity3d.com/Packages/com.unity.xr.hands               |
| **Tương tác thực tế ảo**     | XR Interaction Toolkit | 2.5.2       | docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit |
| **Hiển thị văn bản 3D**      | TextMesh Pro           | 3.0.6       | docs.unity3d.com/Packages/com.unity.textmeshpro            |

> **Bảng 5.2:** _Danh sách thư viện và công cụ sử dụng_

---

### 5.3.2 Kết quả đạt được

Quá trình phát triển đã xây dựng thành công ứng dụng bài giảng tương tác ASL VR hoàn chỉnh dưới dạng tệp cài đặt chạy trực tiếp trên thiết bị kính. Mã nguồn được tổ chức chặt chẽ thành 3 gói chính như đã thiết kế ở phần thiết kế kiến trúc, mỗi gói đóng gói một nhóm chức năng chuyên biệt:

1. **GestureRecognition_Package:** Chứa toàn bộ logic nhận diện các cử chỉ tay tĩnh, động, bộ trung chuyển sự kiện và cơ chế di chuyển bằng tay trần (bao gồm các lớp GestureHub, GestureLesson, TrajectoryRecognizer, UnistrokeRecognizer, GestureTrigger và GestureLocomotionProvider). Gói này có tính mô-đun hóa cao, có thể tái sử dụng trực tiếp cho các dự án thực tế ảo khác có yêu cầu tương tác và di chuyển bằng tay trần.
2. **Progression_Package:** Quản lý tiến trình học tập tổng thể, lưu trữ điểm số, trạng thái phòng học ảo, cơ chế thi cử trắc nghiệm và hoạt ảnh phản hồi của các nhân vật hướng dẫn ảo (bao gồm các lớp ProgressManager, ClassroomManager, QuizManager, NPCKyleController, NPCLobbyInstructorController cùng các lớp dữ liệu học thuật PracticeData và QuizData).
3. **PresentationInteraction_Package:** Quản lý giao diện bảng đeo cổ tay của người học, camera hướng về giao diện người dùng và các tiện ích tùy biến trong editor (bao gồm các lớp WristDashboardUI, WristFollower, UIFaceCamera và RefineWristDashboard).

Dưới đây là bảng thông số thống kê chi tiết về số lượng lớp, số lượng dòng code (Lines of Code - LOC) và dung lượng mã nguồn của từng gói logic trong dự án:

| Tên gói (Package Name)              | Số lượng lớp | Số dòng code (LOC) | Kích thước gói |
| :---------------------------------- | :----------: | :----------------: | :------------: |
| **GestureRecognition_Package**      |      6       |        781         |    24,0 KB     |
| **Progression_Package**             |      8       |       1.233        |    45,0 KB     |
| **PresentationInteraction_Package** |      4       |        355         |    13,6 KB     |
| **Tổng cộng**                       |    **18**    |     **2.369**      |  **82,6 KB**   |

> **Bảng 5.3:** _Thông số chi tiết các gói mã nguồn của ứng dụng_

Việc module hóa sâu sắc các gói mã nguồn giúp tổng thể ứng dụng đạt hiệu suất xử lý tối ưu, dễ bảo trì và mở rộng thêm nhiều phòng học chuyên đề hoặc từ vựng mới trong tương lai mà không làm ảnh hưởng đến cấu trúc nền tảng của hệ thống.
