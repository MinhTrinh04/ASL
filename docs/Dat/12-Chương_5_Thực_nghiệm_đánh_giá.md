# Chương 5: Thực Nghiệm Và Đánh Giá

## 5.1 Thiết kế kiến trúc

### 5.1.1 Lựa chọn kiến trúc phần mềm

Trò chơi được phát triển dựa trên kiến trúc **Component-Based**, một mô hình thiết kế phổ biến trong các game engine như Unity, phù hợp với các ứng dụng VR yêu cầu tính linh hoạt và tương tác thời gian thực. 

Kiến trúc này được áp dụng bằng cách tổ chức mã nguồn thành các component độc lập, sử dụng các script **MonoBehaviour** gắn vào **GameObjects** để quản lý cả dữ liệu (như trạng thái cử chỉ tay, sức khỏe, thông số) và logic xử lý (như điều khiển di chuyển, tấn công, tương tác giao diện người dùng). Mỗi component được thiết kế để thực hiện một chức năng cụ thể, ví dụ: xử lý cử chỉ tay để bắn súng, điều khiển phi thuyền vũ trụ, quản lý hành vi của các loại kẻ địch, hoặc xử lý các nút bấm trong UI. 

Cách tiếp cận này cho phép triển khai nhanh các tính năng như dịch chuyển tức thời, tấn công laser, hoặc tương tác UI, đồng thời duy trì tính mô-đun để dễ dàng mở rộng hoặc điều chỉnh.

#### a, Thành phần chính của Kiến trúc
Kiến trúc Component-Based được xây dựng dựa trên hai thành phần chính:
* **GameObjects:** Các đối tượng trong trò chơi, đóng vai trò như các thực thể chứa các component, ví dụ như nhân vật người chơi, phi thuyền vũ trụ, bốn loại kẻ địch, điểm chuyển tiếp, hoặc các vật thể môi trường. Mỗi GameObject được gắn các component để xác định hành vi và trạng thái của nó.
* **Components:** Các script MonoBehaviour gắn vào GameObjects, chứa cả dữ liệu (như vị trí, sức khỏe, trạng thái cử chỉ) và logic xử lý (như di chuyển, tấn công, hoặc tương tác UI). Các component được thiết kế độc lập, cho phép dễ dàng thêm hoặc sửa đổi tính năng mà không ảnh hưởng đến toàn bộ hệ thống.

#### b, GameObjects trong Trò chơi
GameObjects được sử dụng để đại diện cho các đối tượng chính trong ba màn chơi của trò chơi:
* **Nhân vật người chơi:** Xuất hiện trong màn 1 và màn 3, được điều khiển bằng cử chỉ tay để thực hiện các hành động như di chuyển, bắn súng, hoặc chắn đạn. Các component như `PlayerAction` và `PlayerHealthController` được gắn để quản lý hành động và sức khỏe, cho phép người chơi tương tác với kẻ địch hoặc môi trường.
* **Phi thuyền vũ trụ:** Có mặt trong màn 2, cho phép người chơi điều khiển để di chuyển, xoay, và bắn trong không gian. Các component như `SpaceShipController` và `PlayerShipAction` được gắn để xử lý các hành động này, đảm bảo trải nghiệm điều khiển mượt mà.
* **Kẻ địch:** Bao gồm bốn loại, mỗi loại có hành vi riêng biệt:
  * **HoverBot:** Kẻ địch di chuyển lơ lửng, xuất hiện ở màn 1 và màn 3, tấn công người chơi bằng các đòn bắn cơ bản. Component `EnemyControl` và `DetectionModule` được sử dụng để điều khiển di chuyển và nhắm mục tiêu.
  * **Turret:** Kẻ địch cố định, bắn đạn tự động khi phát hiện người chơi, xuất hiện ở màn 1 và màn 3. Component `LazerAttackController` được gắn để quản lý tấn công laser.
  * **SpaceFighterShip:** Phi thuyền địch di chuyển nhanh, xuất hiện ở màn 2, nhắm vào phi thuyền người chơi với các đòn tấn công linh hoạt. Component `DetectionModule` và `EnemyControl` được sử dụng để xử lý hành vi.
  * **Boss cuối:** Kẻ địch mạnh nhất ở màn 3, yêu cầu người chơi sử dụng tất cả kỹ năng để đánh bại. Component `DetectionModule` và `LazerAttackController` được gắn để thực hiện các đòn tấn công phức tạp.
* **Điểm chuyển tiếp:** Các đối tượng như phi thuyền vũ trụ ở màn 1 hoặc cánh cổng ở màn 2, cho phép chuyển giữa các màn. Component `GameManager` được sử dụng để kiểm tra tương tác với các điểm này.
* **Môi trường:** Các vật thể như địa hình, chướng ngại vật, hoặc tàn tích, được gắn `Transform` và `Collider` để hỗ trợ tương tác vật lý với người chơi, phi thuyền, hoặc kẻ địch.

#### c, Components
Các component được triển khai dưới dạng script MonoBehaviour, mỗi script chứa dữ liệu và logic để thực hiện một chức năng cụ thể, đảm bảo tính độc lập và dễ tái sử dụng. Các component chính bao gồm:

* **Components của Unity:**
  * **Transform:** Lưu trữ và cập nhật vị trí, xoay, và tỷ lệ của GameObjects, ví dụ: di chuyển nhân vật người chơi theo cử chỉ trỏ tay hoặc xoay phi thuyền vũ trụ theo cử chỉ úp lòng bàn tay.
  * **Rigidbody:** Quản lý vật lý, như áp dụng trọng lực cho nhân vật ở màn 1 và màn 3, hoặc cho phép phi thuyền vũ trụ di chuyển tự do trong không gian ở màn 2. Component này được cấu hình để xử lý va chạm và vận tốc, ví dụ, khi phi thuyền va chạm với thiên thạch hoặc SpaceFighterShip.
  * **Collider:** Xử lý va chạm giữa nhân vật, phi thuyền, kẻ địch, và môi trường. `BoxCollider` được sử dụng cho nhân vật và `MeshCollider` cho các vật thể phức tạp như SpaceFighterShip hoặc địa hình, đảm bảo phát hiện va chạm chính xác.

* **Components tự phát triển:**
  * **StaticHandGesture:** Thu nhận dữ liệu cử chỉ tay từ `XRHandTrackingEvent`, lưu trữ trạng thái như vị trí ngón tay hoặc góc bàn tay, và xử lý các cử chỉ như trỏ tay để di chuyển, mở lòng bàn tay trái để lao nhanh, hoặc giơ ngón cái để dịch chuyển tức thời. Component này được sử dụng ở màn 1 và màn 3 để điều khiển nhân vật, và ở màn 2 để điều khiển phi thuyền.
  * **PlayerAction:** Quản lý các hành động của nhân vật người chơi, lưu trữ dữ liệu như vị trí đích hoặc trạng thái bắn, và thực hiện logic để di chuyển (theo trục XZ), lao nhanh, dịch chuyển tức thời, bắn (giơ ngón trỏ tay phải), hoặc chắn đạn (mở lòng bàn tay phải). Component này tích hợp với `StaticHandGesture` để phản ứng theo cử chỉ, được áp dụng ở màn 1 và màn 3.
  * **PlayerHealthController:** Lưu trữ giá trị sức khỏe của người chơi và xử lý logic hồi máu khi nhặt vật phẩm từ HoverBot hoặc Turret, hoặc trừ máu khi bị tấn công bởi kẻ địch hoặc boss cuối. Component này được cấu hình để hồi đầy máu khi nhặt vật phẩm, đảm bảo người chơi tiếp tục chiến đấu ở màn 1 và màn 3.
  * **PlayerStatusControl:** Lưu trữ thông số người chơi, như sức mạnh đạn, thời gian hồi chiêu, và tốc độ di chuyển, đồng thời xử lý logic cập nhật thông số dựa trên dữ liệu từ UI. Component này điều chỉnh hiệu suất của `PlayerAction`, ví dụ, tăng sát thương bắn ở màn 3 để đối phó với boss cuối.
  * **StatusProfile:** Quản lý dữ liệu giao diện người dùng, lưu trữ các giá trị như thông số hiện tại của người chơi, và truyền chúng đến `PlayerStatusControl`. Component này hiển thị và cập nhật thông tin trên UI, như sức khỏe hoặc thông số, ở cả ba màn.
  * **VirtualButton:** Xử lý các nút bấm trong UI, lưu trữ trạng thái nút (như nhấn hay không nhấn) và thực hiện logic tương tác, ví dụ: kích hoạt thay đổi thông số, quay về menu, hoặc khởi động lại màn chơi. Component này cho phép người chơi sử dụng cử chỉ tay để tương tác với UI, được sử dụng xuyên suốt các màn.
  * **PlayerShipAction:** Lưu trữ trạng thái hành động phi thuyền vũ trụ, như hướng di chuyển hoặc góc xoay, và xử lý các hành động như di chuyển (trỏ ngón trỏ), xoay (úp lòng bàn tay), và bắn (trỏ ngón trỏ tay phải). Component này tích hợp với `StaticHandGesture` để điều khiển phi thuyền ở màn 2, đảm bảo trải nghiệm VR mượt mà.
  * **SpaceShipController:** Quản lý trạng thái phi thuyền (vị trí, vận tốc) và thực hiện logic điều khiển phi thuyền dựa trên `PlayerShipAction`. Component này cho phép phi thuyền di chuyển linh hoạt trong không gian, né tránh SpaceFighterShip hoặc thiên thạch ở màn 2.
  * **ShipHealthController:** Lưu trữ sức khỏe phi thuyền và xử lý logic trừ máu khi bị tấn công bởi SpaceFighterShip hoặc va chạm thiên thạch, đồng thời xác định trạng thái hết máu. Component này tích hợp với `GameManager` để xử lý thất bại ở màn 2.
  * **EnemyControl:** Quản lý trạng thái bốn loại kẻ địch (HoverBot, Turret, SpaceFighterShip, boss cuối) và thực hiện logic tấn công, sử dụng dữ liệu từ `DetectionModule` để nhắm mục tiêu. Component này điều khiển di chuyển lơ lửng của HoverBot hoặc tấn công nhanh của SpaceFighterShip.
  * **DetectionModule:** Lưu trữ thông tin mục tiêu (như vị trí AimObject trong layer Player) và xử lý logic phát hiện trong phạm vi DetectionRange và AttackRange. Component này cho phép HoverBot, Turret, SpaceFighterShip, và boss cuối nhắm chính xác người chơi hoặc phi thuyền.
  * **LazerAttackController:** Quản lý trạng thái tấn công laser của boss cuối, thực hiện logic bắn dựa trên mục tiêu từ `DetectionModule`. Component này được sử dụng ở màn 3.
  * **TimelineShip:** Lưu trữ thông tin diễn hoạt (như thời điểm bắt đầu) và xử lý cảnh rơi phi thuyền ở đoạn mở đầu, tạo trải nghiệm nhập vai cho người chơi trước khi bắt đầu màn 1.
  * **UpperCharacter:** Quản lý trạng thái diễn hoạt nâng người chơi ở các cảnh tương ứng, tăng tính hấp dẫn cho trò chơi.

### 5.1.2 Thiết kế tổng quan

Mã nguồn được tổ chức thành bốn gói (package) chính: `Enemy_Package`, `Manager_Package`, `Player_Package`, và `SpaceShip_Package`, đảm bảo cấu trúc rõ ràng, giảm thiểu xung đột tên, và tăng tính bảo trì.

> **Hình 5.1:** *Biểu đồ phụ thuộc gói của hệ thống*

* **Enemy_Package:** Quản lý hành vi di chuyển và tấn công của bốn loại kẻ địch (HoverBot, Turret, SpaceFighterShip, boss cuối) thông qua các script như `EnemyControl`, `DetectionModule`, `LazerAttackController`. Gói này phụ thuộc vào `Player_Package` và `SpaceShip_Package` để phát hiện mục tiêu.
* **Manager_Package:** Chứa `GameManager` và các script quản lý trạng thái trò chơi, chuyển màn, hiển thị UI và hoạt ảnh phi thuyền. Gói này trao đổi dữ liệu giữa UI, nhân vật và phi thuyền, phụ thuộc vào `Player_Package` và `SpaceShip_Package`.
* **SpaceShip_Package:** Bao gồm các script điều khiển phi thuyền ở màn 2 như `SpaceFighterAimController`, `SpaceShipController`, `ShipHealthController`, nhận dữ liệu điều khiển từ `Player_Package` để thực hiện thao tác theo cử chỉ tay.
* **Player_Package:** Quản lý nhân vật người chơi, xử lý cử chỉ tay, máu và trạng thái, đồng thời cung cấp dữ liệu cho các gói khác như `SpaceShip_Package`.

### 5.1.3 Thiết kế chi tiết gói

#### a, Player Package

> **Hình 5.2:** *Thiết kế chi tiết của Player Package*

Đây là gói quan trọng nhất giúp người chơi điều khiển nhân vật và tương tác với mọi yếu tố trong game. Lớp `PlayerStatusController` giữ vai trò trung tâm, quản lý trạng thái tổng thể của người chơi, bao gồm dữ liệu sức khỏe và thông tin đầu vào. 

`PlayerHealthController` chịu trách nhiệm xử lý logic về sát thương và trạng thái sống/chết của người chơi, đồng thời cung cấp thông tin sức khỏe cho `PlayerStatusController` để hỗ trợ các quyết định trong game. `PlayerActions` điều khiển các hành động của nhân vật ở chế độ đi bộ, bao gồm di chuyển theo hướng tay trái, bắn, kích hoạt lá chắn và dịch chuyển bằng cách chiếu tia xác định vị trí đích. 

`PlayerShipActions` quản lý hành động của người chơi khi điều khiển phi thuyền vũ trụ, gửi các tương tác đến `SpaceshipController` để thực hiện di chuyển theo hướng dựa trên cử chỉ tay hoặc bắn. Đồng thời, `PlayerShipActions` gửi dữ liệu đến `SpaceFighterAimController` để điều khiển trạng thái ngắm bắn của phi thuyền.

#### b, SpaceShip Package

> **Hình 5.3:** *Thiết kế chi tiết của SpaceShip Package*

Đây là gói tập trung vào các tương tác vật lý mà phi thuyền vũ trụ thực hiện sau khi nhận được dữ liệu từ **Player Package**.

Lớp `SpaceshipController` chịu trách nhiệm điều khiển phi thuyền vũ trụ, nhận dữ liệu từ các lớp thuộc Player Package để thực hiện các hành động như di chuyển theo hướng chỉ định, xoay (yaw, pitch, roll) dựa trên cử chỉ tay, hoặc bắn thông qua component `Triggerable`. Lớp này sử dụng `Rigidbody` để áp dụng lực và mô-men xoắn, đảm bảo chuyển động vật lý chính xác, và hỗ trợ tăng tốc về phía trước (boost) với lực cố định.

Lớp `SpaceFighterAimControl` hỗ trợ tính năng nhắm bắn tự động, tìm kiếm kẻ thù trong một bán kính xác định (dựa trên `LayerMask`) và xoay phi thuyền về phía mục tiêu gần nhất, sử dụng phép toán góc (`Vector3.Angle`) để xác định hướng. Lớp này cung cấp trạng thái nhắm bắn (`IsAiming`) để `SpaceshipController` điều chỉnh logic di chuyển.

Lớp `EnterVehicle` quản lý quá trình chuyển đổi trạng thái của người chơi giữa chế độ đi bộ và điều khiển phi thuyền, kích hoạt hoặc vô hiệu hóa các hành động của `PlayerShipActions` dựa trên trạng thái lên/xuống phi thuyền.

#### c, Manager Package

> **Hình 5.4:** *Thiết kế chi tiết của Manager Package*

**Manager Package** là gói quan trọng để hỗ trợ người chơi điều khiển nhân vật và quản lý các tương tác trong trò chơi.

Lớp `GameManager` đóng vai trò trung tâm, chịu trách nhiệm quản lý trạng thái toàn cục của trò chơi, như chế độ chơi và các quy tắc tổng thể. Lớp này cho phép quản lý nhiều nút ảo và nhiều đối tượng chuyển tiếp màn hình để điều phối các chức năng giao diện.

Lớp `VirtualButton` xử lý các nút ảo trong giao diện, cung cấp vị trí tương tác cho người chơi để thực hiện các hành động như điều chỉnh trạng thái hoặc gửi lệnh. Lớp `UIStatusProfile` quản lý giao diện trạng thái, nhận dữ liệu từ `PlayerStatusController` trong package Player để cập nhật thông tin như sức khỏe hoặc chế độ chơi, và hỗ trợ quyết định kết thúc màn chơi khi cần.

Lớp `ChangeScreenManager` quản lý việc chuyển đổi màn hình hoặc giao diện, nhận dữ liệu từ `PlayerActions` trong package Player để thực hiện chuyển màn hoặc hiển thị các đoạn cutscene động dựa trên trạng thái và vị trí của người chơi.

Lớp `UpperCharacter` và `TimeLineShip` là các lớp để tạo realtime cutscene, về cơ bản chỉ là thay đổi chuyển động của các đối tượng khi đạt một điều kiện nhất định nào đó.

#### d, Enemy Package

> **Hình 5.5:** *Thiết kế chi tiết của Enemy Package*

**Enemy Package** chứa các lớp hỗ trợ thực hiện hành vi của kẻ thù trong trò chơi.

Lớp `DetectionModule` đóng vai trò trung tâm, chịu trách nhiệm phát hiện người chơi để cung cấp thông tin cho các hành động của kẻ thù. Lớp này sử dụng `PlayerActions` trong package Player, truy xuất dữ liệu như vị trí hoặc trạng thái hành động của người chơi để hỗ trợ hệ thống AI trong việc theo dõi và xác định mục tiêu tấn công.

Lớp `LazerAttackController` quản lý hành vi tấn công của boss. Đối với boss trong trò chơi sẽ sử dụng lối tấn công chính là tấn công bằng laser, lớp này sử dụng dữ liệu từ `DetectionModule` để xác định vị trí người chơi và thực hiện các đòn tấn công laser chính xác.

Lớp `EnemyController` điều phối hành vi tổng thể của kẻ thù, như di chuyển hoặc phản ứng với người chơi, cũng phụ thuộc vào `DetectionModule` để nhận thông tin về mục tiêu và đưa ra các quyết định chiến thuật. Enemy Package phối hợp với package Player để đảm bảo kẻ thù có thể phát hiện và tương tác với người chơi, tạo nên các tình huống đối kháng trong trò chơi.

## 5.2 Thiết kế chi tiết

> **Hình 5.6:** *Các lớp quan trọng trong việc điều khiển và vận hành trò chơi*

Bốn lớp cốt lõi trong hệ thống VR Gesture, bao gồm `StaticHandGesture`, `PlayerActions`, `PlayerShipActions`, và `SpaceshipController`, được thiết kế để truyền sự kiện thông qua mẫu thiết kế **Observer**, sử dụng cơ chế **UnityEvent** nhằm quản lý và xử lý các sự kiện một cách hiệu quả, như minh họa trong Hình 5.6. 

Cụ thể, lớp `StaticHandGesture` đăng ký các sự kiện như `gesturePerformed` và `gestureEnded` thông qua `UnityEvent`, cho phép các lớp khác như `PlayerActions` và `PlayerShipActions` lắng nghe và phản hồi khi có thay đổi. Khi một sự kiện đã được đăng ký (như phát hiện cử chỉ tay tĩnh) và được kích hoạt bởi `StaticHandGesture` thông qua phương thức `m_GesturePerformed.Invoke()`, thông báo sẽ được gửi đến `PlayerActions` và `PlayerShipActions`. Sau khi nhận thông báo, `PlayerActions` hoặc `PlayerShipActions` sẽ thực hiện các hành động tương tác tương ứng với cử chỉ, chẳng hạn như di chuyển nhân vật, bắn, hoặc điều khiển phi thuyền vũ trụ, bằng cách cập nhật trạng thái tay và gọi các phương thức xử lý hành động. 

Trong khi đó, `PlayerShipActions` tương tác trực tiếp với `SpaceshipController` bằng cách gọi các phương thức như `HandlePoint` hoặc `HandleFire` để thực hiện các lệnh điều khiển phi thuyền.

> **Hình 5.7:** *Luồng thực hiện khi người chơi điều khiển nhân vật chính*

Luồng hoạt động của `PlayerActions` được thể hiện trong Hình 5.7, tập trung vào chế độ đi bộ của người chơi. Khi nhận tín hiệu từ `StaticHandGesture` qua sự kiện `gesturePerformed`, `PlayerActions` cập nhật trạng thái tay bằng cách thay đổi giá trị của `rightHandStateName` và `leftHandStateName` trong phương thức `Update`. 

* Cụ thể, nếu `rightHandStateName` được đặt thành `"Firing"`, phương thức `HandleStates` sẽ gán `rightHandState` thành `Firing` và gọi hàm `Firing` để thực hiện hành động bắn, trong đó dữ liệu count tăng lên và trạng thái cooldown được kiểm tra để quyết định có bắn hay không.
* Nếu `rightHandStateName` là `"Shield"`, `HandleStates` gán `rightHandState` thành `Shield` và gọi `Shield` để kích hoạt lá chắn, thay đổi trạng thái hiển thị của `ShieldModel`.
* Tương tự, nếu `leftHandStateName` được đặt thành `"MoveDirectionPoint"`, `HandleStates` gán `leftHandState` thành `MoveDirectionPoint` và gọi `MoveDirectionPoint` để di chuyển nhân vật theo hướng tay trái, cập nhật vị trí của `playerTransform` dựa trên `leftHandTransform.forward`.
* Nếu `leftHandStateName` là `"Teleport_Aim"`, `HandleStates` gọi `Teleport_Aim` để xác định vị trí dịch chuyển, sau đó `Teleport_Start` được gọi để cập nhật vị trí nhân vật và kích hoạt hiệu ứng.

> **Hình 5.8:** *Luồng thực hiện khi người chơi điều khiển phi thuyền*

Luồng hoạt động của `PlayerShipActions` được mô tả trong Hình 5.8, áp dụng khi người chơi điều khiển phi thuyền vũ trụ. Sau khi nhận tín hiệu từ `StaticHandGesture` qua `gesturePerformed`, `PlayerShipActions` cập nhật trạng thái tay trong phương thức `Update` bằng cách thay đổi `rightHandStateName` và `leftHandStateName`. 

* Nếu `rightHandStateName` được đặt thành `"Firing"`, `HandleStates` gán `rightHandState` thành `Firing` và gọi `Firing`, sau đó gọi `SpaceshipController.HandleFire(true)` để thực hiện hành động bắn, thay đổi trạng thái của triggerable trong `SpaceshipController`.
* Nếu `rightHandStateName` là `"StopFiring"`, `HandleStates` gọi `StopFiring` và `SpaceshipController.HandleFire(false)` để ngừng bắn.
* Với `leftHandStateName`, nếu được đặt thành `"PointDirectionPoint"`, `HandleStates` gán `leftHandState` thành `PointDirectionPoint` và gọi `PointDirectionPoint`, sau đó gọi `HandlePoint` để di chuyển phi thuyền theo hướng tay, cập nhật lực vật lý của Rigidbody trong `SpaceshipController`.
* Nếu `leftHandStateName` là `"PalmDirectionPoint"`, `HandleStates` gọi `PalmDirectionPoint` và `SpaceshipController.HandlePalm(leftHandPoke)` để roll phi thuyền.
* Nếu là `"ThumbUpDirection"` hoặc `"ThumbDownDirection"`, `HandleStates` lần lượt gọi `ThumbUpDirection` hoặc `ThumbDownDirection`, sau đó gọi `HandleThumbUp` hoặc `HandleThumbDown` để pitch phi thuyền lên hoặc xuống.

## 5.3 Xây dựng ứng dụng

### 5.3.1 Thư viện và công cụ sử dụng

Dưới đây là danh sách chi tiết các công cụ, thư viện và phiên bản được sử dụng trong suốt quá trình xây dựng trò chơi:

| Mục đích | Công cụ | Phiên bản | Địa chỉ URL |
| :--- | :--- | :--- | :--- |
| **Code editor** | Visual Studio Code | 2019 | visualstudio.microsoft.com |
| **Game Engine** | Unity Engine | 2022.3.501f1 | unity.com |
| **XR Hands & Gesture** | Unity XR Hands | 1.4.3 | com.unity.xr.hands@1.4 |

> **Bảng 5.1:** *Danh sách thư viện và công cụ sử dụng*

### 5.3.2 Kết quả đạt được

Quá trình phát triển tạo ra hệ thống trò chơi có thể chơi được hoàn chỉnh. Hệ thống gồm 4 gói chính chứa logic của trò chơi:
1. **Player Package:** Chứa các logic điều khiển người chơi và kích hoạt các hành động khi nhận diện cử chỉ, gói này có thể tái sử dụng ở bất cứ trò chơi nào sử dụng cơ chế điều khiển bằng cử chỉ.
2. **SpaceShip Package:** Chứa logic điều khiển phi thuyền, có thể tái sử dụng cho các trò chơi thuộc loại điều khiển phi thuyền không gian.
3. **Manager Package:** Chứa logic của màn chơi và các nút điều khiển. Về mặt điều khiển UI, logic của gói này có thể tái sử dụng cho bất cứ trò chơi VR nào.
4. **Enemy Package:** Chứa logic điều khiển kẻ địch.

Dưới đây là thông số thống kê chi tiết cho từng gói mã nguồn:

| Tên gói (Package Name) | Số lượng lớp (No. of classes) | Số dòng code (Lines of codes) | Kích thước gói (Package size) |
| :--- | :---: | :---: | :---: |
| **Player Package** | 4 | 607 | 23.9KB |
| **SpaceShip Package** | 5 | 404 | 18.0KB |
| **Manager Package** | 11 | 390 | 16.0KB |
| **Enemy Package** | 3 | 710 | 28.0KB |

> **Bảng 5.2:** *Thông số chi tiết các gói mã nguồn*

## 5.4 Sản phẩm

Phần này giúp người chơi hiểu rõ hơn về các hoạt động, chức năng chính và trải nghiệm thực tế trong trò chơi, đồng thời cung cấp cái nhìn tổng quan về hành trình phiêu lưu, các thử thách và những điểm đặc sắc mà trò chơi mang lại.

Ngay khi bắt đầu, người chơi được đưa vào một không gian nhà chính rộng lớn, hiện đại, đóng vai trò là căn cứ khởi đầu của toàn bộ hành trình. Khung cảnh tại đây được thiết kế yên bình, ánh sáng dịu nhẹ, kết hợp với các chi tiết kiến trúc công nghệ cao, tạo cảm giác an toàn và thân thiện cho người mới. Trong giai đoạn này, người chơi có thể tự do quan sát, làm quen với thao tác di chuyển, ngắm nhìn cảnh vật xung quanh và chuẩn bị tinh thần cho những thử thách phía trước.

> **Hình 5.9:** *Khung cảnh nhà chính khi trò chơi bắt đầu*

Đây cũng là nơi người chơi tiếp nhận các hướng dẫn cơ bản về điều khiển, sử dụng vũ khí và kỹ năng phòng thủ, giúp làm quen với hệ thống gameplay mà không bị áp lực từ kẻ địch.

Bầu không khí yên bình nhanh chóng bị phá vỡ khi một phi thuyền của kẻ địch bất ngờ rơi xuống gần căn cứ, kéo theo sự xuất hiện của các Hover Bot – những robot bay nhỏ, linh hoạt được thả ra từ phi thuyền địch. Hover Bot là đối thủ lý tưởng để người chơi luyện tập khả năng bắn súng, sử dụng khiên phòng thủ và rèn luyện phản xạ né tránh. Các đợt tấn công ban đầu này không quá khó, giúp người chơi từng bước làm quen với nhịp độ chiến đấu, đồng thời cảm nhận rõ ràng sự chuyển biến từ trạng thái an toàn sang nguy hiểm, tạo động lực khám phá tiếp các thử thách tiếp theo.

> **Hình 5.10:** *Hover Bot bị rơi ra từ phi thuyền*

Tiếp tục tiến vào khu vực phi thuyền vũ trụ, người chơi sẽ đối mặt với Turret Bot – loại robot phòng thủ cố định, thường được bố trí ở các vị trí chiến lược như gần sông, lối đi hoặc các khu vực trọng yếu. Turret Bot sở hữu hỏa lực mạnh và khả năng phát hiện mục tiêu từ xa, buộc người chơi phải vận dụng kỹ năng di chuyển, tận dụng các vật cản tự nhiên để ẩn nấp và lên kế hoạch tấn công hợp lý. 

Sự xuất hiện của Turret Bot không chỉ tăng độ khó cho trò chơi mà còn giúp người chơi rèn luyện tư duy chiến thuật, kết hợp giữa phòng thủ và tấn công một cách linh hoạt.

> **Hình 5.11:** *Turret Bot cản đường người chơi*

Sau khi vượt qua các đợt tấn công, người chơi sẽ tiếp cận được khối cầu năng lượng trung chuyển. Đây là thiết bị hỗ trợ di chuyển lên các khu vực cao hơn, cụ thể là tòa tháp lớn nơi đặt phi thuyền. Việc sử dụng khối cầu năng lượng không chỉ giúp người chơi làm quen với các cơ chế di chuyển đặc biệt mà còn tạo cảm giác mới lạ, tăng tính tương tác với môi trường trong game.

> **Hình 5.12:** *Khối cầu năng lượng trung chuyển*

Khi vào bên trong phi thuyền, người chơi sẽ điều khiển phi thuyền tiến vào lỗ hổng không gian, mở ra màn chơi thứ hai với bối cảnh vũ trụ rộng lớn. Đây là bước chuyển tiếp quan trọng, đánh dấu sự thay đổi lớn về môi trường và thử thách, khi người chơi rời khỏi hành tinh quen thuộc để bước vào không gian vô tận đầy bí ẩn.

> **Hình 5.13:** *Cổng không gian để di chuyển giữa hành tinh xanh và bên ngoài vũ trụ*

Màn hai mở ra một không gian vũ trụ vô tận, nơi người chơi có thể quan sát các thiên thể, phi thuyền vũ trụ của kẻ địch và cổng không gian dẫn tới hành tinh tiếp theo. Trong môi trường không trọng lực này, người chơi phải khéo léo điều khiển phi thuyền, né tránh các thiên thạch, đồng thời có thể lựa chọn tấn công các phi thuyền địch để tích lũy điểm nâng cấp kỹ năng. Sự đa dạng về thử thách và môi trường giúp tăng chiều sâu cho gameplay, đồng thời mang lại cảm giác phiêu lưu, chinh phục không gian thực thụ.

> **Hình 5.14:** *Không gian vũ trụ vô tận*

Những trận chiến trong không gian đòi hỏi người chơi phải phối hợp linh hoạt giữa di chuyển, né tránh và tấn công. Việc đối đầu với các phi thuyền vũ trụ của kẻ địch không chỉ giúp người chơi rèn luyện kỹ năng điều khiển phi thuyền mà còn mang lại phần thưởng xứng đáng dưới dạng điểm nâng cấp, mở ra nhiều lựa chọn phát triển sức mạnh cho nhân vật.

> **Hình 5.15:** *Trận chiến trong không gian giữa người chơi và phi thuyền vũ trụ*

Sau khi vượt qua những trận chiến căng thẳng với các phi thuyền vũ trụ của kẻ địch trong không gian, người chơi sẽ tiếp tục hành trình tiến gần đến hành tinh chết – nơi ẩn chứa những bí ẩn và nguy hiểm lớn nhất của trò chơi. Trên đường đi, người chơi có thể quan sát thấy cổng không gian khổng lồ của kẻ địch, đây là một công trình mang đậm dấu ấn công nghệ và đóng vai trò như cửa ngõ cuối cùng dẫn tới vùng đất hoang tàn phía trước. 

Việc tiếp cận cổng không gian này đòi hỏi người chơi phải khéo léo điều khiển phi thuyền, né tránh các vật thể trôi nổi và mối nguy từ phi thuyền địch, cũng như cần sự chuẩn bị kỹ lưỡng về kỹ năng để sẵn sàng đối mặt với thử thách lớn nhất đang chờ đợi phía sau.

> **Hình 5.16:** *Cổng không gian bên ngoài hành tinh chết*

Màn ba đưa người chơi đến một hành tinh chết với khung cảnh hoang tàn, đổ nát. Tại đây, người chơi phải vận dụng tối đa kỹ năng di chuyển, sử dụng các tảng đá lớn để luyện tập dịch chuyển tức thời và tìm đường tiếp cận khu vực của trùm cuối. Không gian u ám, tàn tích và robot lang thang tạo nên bầu không khí căng thẳng, báo hiệu trận chiến quyết định sắp diễn ra.

> **Hình 5.17:** *Khung cảnh hành tinh chết*

Để tiếp cận khu vực của trùm cuối, người chơi có thể lựa chọn nhiều con đường khác nhau. Một số lối đi là các hẻm đá hẹp, đòi hỏi phải di chuyển khéo léo. Ngoài ra, người chơi còn có thể sử dụng kỹ năng dịch chuyển tức thời để nhảy qua các tảng đá lớn nhằm rút ngắn quãng đường. Sự đa dạng trong cách tiếp cận này giúp mỗi lượt chơi trở nên mới mẻ, đồng thời khuyến khích người chơi sáng tạo, thử nghiệm các chiến thuật khác nhau để tối ưu hóa khả năng sinh tồn.

> **Hình 5.18:** *Lối đi vào màn đánh trùm cuối*

Cao trào của trò chơi là trận chiến với trùm cuối – một thực thể sở hữu khả năng phóng tia năng lượng cực mạnh. Người chơi phải vận dụng tối đa kỹ năng dịch chuyển, né tránh và tấn công linh hoạt để vượt qua thử thách này. 

Chiến thắng trùm cuối cũng là lúc người chơi hoàn thành toàn bộ hành trình chinh phục thế giới ảo, khẳng định bản lĩnh và kỹ năng của mình trong môi trường thực tế ảo đầy kịch tính và cuốn hút.

> **Hình 5.19:** *Trận chiến giữa người chơi và trùm cuối*

## 5.5 Triển khai

*Astral Reclaim* được phát triển và triển khai chủ yếu trên nền tảng **Meta Quest 2**, một thiết bị VR độc lập với khả năng xử lý cử chỉ tay và hiệu suất cao, phù hợp cho trải nghiệm bắn súng kết hợp phiêu lưu. Ngoài ra, trò chơi được thiết kế để tương thích với các nền tảng VR khác như **Pico**, tận dụng các API chuẩn của Unity XR để đảm bảo khả năng chuyển đổi linh hoạt. Quy trình triển khai bao gồm cấu hình môi trường phát triển, tối ưu hóa hiệu suất, và kiểm thử trên thiết bị thực tế nhằm mang lại trải nghiệm VR mượt mà qua ba màn chơi.

### 5.5.1 Môi trường phát triển và triển khai

Trò chơi được phát triển trên nền tảng **Unity 2022.3 LTS**, sử dụng các công cụ chính bao gồm **Unity Editor** để xây dựng và tích hợp các script MonoBehaviour, **Visual Studio** để chỉnh sửa và gỡ lỗi mã nguồn C#, cùng với **XR Interaction Toolkit** để hỗ trợ các thao tác tương tác trong môi trường thực tế ảo. 

Để đảm bảo khả năng tương thích với nhiều thiết bị, dự án sử dụng **Oculus Integration SDK** cho Meta Quest 2 và **OpenXR Plugin** để mở rộng sang các nền tảng VR khác như Pico. Khi triển khai trên thiết bị Pico, cần bổ sung thêm **Pico Unity Integration SDK**.

Quá trình kiểm thử và phát triển chủ yếu được thực hiện trên thiết bị Meta Quest 2 với cấu hình phần cứng như trình bày ở Bảng 5.3 dưới đây:

| Tên cấu hình | Thông số phần cứng |
| :--- | :--- |
| **Hệ điều hành** | Android 10 |
| **CPU** | Qualcomm Snapdragon XR2 |
| **RAM** | 6GB |
| **Bộ nhớ trong** | 128GB |
| **Độ phân giải** | 1832 x 1920 |

> **Bảng 5.3:** *Thông số cấu hình thiết bị triển khai trò chơi*

### 5.5.2 Quy trình triển khai và cài đặt

Để triển khai trò chơi lên thiết bị **Meta Quest 2**, ứng dụng được xuất bản dưới dạng tệp **APK** thông qua chế độ *Android Build Settings* với kiến trúc ARM64. Quá trình cài đặt nội bộ sử dụng nền tảng **SideQuest** và chế độ Sideload để tải APK lên thiết bị. Đối với thiết bị **Pico**, trò chơi được đóng gói và phân phối qua *Pico Developer Platform* với quy trình build tương tự.

Để tái tạo môi trường phát triển, người dùng cần cài đặt **Unity 2022.3 LTS**, các SDK tương ứng (Oculus Integration, OpenXR hoặc Pico SDK), và đảm bảo thiết bị VR hỗ trợ hand tracking hoặc controller truyền thống. Mã nguồn được tổ chức thành các gói riêng biệt cho từng chức năng (Player, Enemy, UI, Environment), thuận tiện cho việc bảo trì và mở rộng.

### 5.5.3 Tối ưu hóa hiệu suất

Trong quá trình phát triển, nhiều biện pháp tối ưu hóa đã được áp dụng để đảm bảo trò chơi vận hành mượt mà trên các thiết bị VR phổ thông:
* **Tối ưu hóa đa giác:** Số lượng đa giác trong các mô hình 3D như HoverBot, Turret và phi thuyền vũ trụ được giảm thiểu tối đa.
* **Tối ưu hóa Texture:** Texture sử dụng định dạng nén để tiết kiệm bộ nhớ.
* **Tối ưu hóa môi trường:** Các vật thể môi trường ở màn 1 và 3 được tối giản nhằm duy trì tốc độ khung hình ổn định ở mức **50-60 FPS**.
* **Tối ưu hóa giao diện:** Hệ thống giao diện người dùng (UI) được tối ưu bằng cách sử dụng canvas tĩnh, chỉ cập nhật khi có thay đổi về trạng thái sức khỏe hoặc điểm nâng cấp, giúp giảm tải cho GPU, đặc biệt trong các pha chiến đấu với boss cuối.

### 5.5.4 Kiểm thử và đánh giá thực tế

Quy trình kiểm thử được tiến hành toàn diện trên **Meta Quest 2**, bao gồm kiểm thử chức năng, kiểm thử hiệu suất và kiểm thử tương thích. 

* **Kiểm thử chức năng:** Các module như `StaticHandGesture`, `PlayerAction`, `PlayerShipAction` được kiểm tra kỹ lưỡng để đảm bảo nhận diện đúng các cử chỉ tay và phản hồi chính xác với hành động của người chơi. `DetectionModule` đảm bảo kẻ địch như HoverBot, Turret và boss cuối luôn nhận diện và tấn công đúng mục tiêu. Quản lý chuyển màn và giao diện người dùng được kiểm tra thông qua `GameManager`.
* **Kiểm thử hiệu suất:** Tốc độ khung hình được đo lường ở các màn chơi, đặc biệt khi xuất hiện nhiều phi thuyền địch hoặc trong các pha giao tranh căng thẳng với boss cuối. Kết quả kiểm thử cho thấy trò chơi duy trì ổn định ở mức **50-60 FPS** trên Meta Quest 2. 
* **Kiểm thử tương thích:** Trò chơi cũng được kiểm tra trên **Meta Quest 3** và các thiết bị **Pico**, với các điều chỉnh nhỏ về UI và điều khiển để đảm bảo trải nghiệm nhất quán.

### 5.5.5 Thống kê và phản hồi thử nghiệm

Trong quá trình thử nghiệm nội bộ, trò chơi đã được cài đặt và trải nghiệm bởi nhóm phát triển và một số người dùng thử. Thời gian phản hồi của các thao tác chính đều dưới **50 ms**, đảm bảo cảm giác mượt mà và tức thời. 

Người dùng đánh giá cao tính nhập vai của hệ thống cử chỉ tay và giao diện tối giản, đồng thời ghi nhận hiệu suất ổn định ngay cả trong các tình huống chiến đấu đông kẻ địch. Một số phản hồi góp ý về giao diện và độ nhạy của cử chỉ đã được tiếp thu và điều chỉnh trong các phiên bản cập nhật tiếp theo.

Nhìn chung, quá trình triển khai, kiểm thử và tối ưu hóa đã giúp trò chơi vận hành ổn định trên các thiết bị VR phổ thông, sẵn sàng cho việc mở rộng thử nghiệm với số lượng người dùng lớn hơn trong tương lai.
