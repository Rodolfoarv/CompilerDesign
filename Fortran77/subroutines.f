      program callex
      integer m,n

      m = 1
      n = 2

      call iswap(m,n)
      write(*,*) m,n
      stop
      end



      subroutine iswap(a,b)
      integer a,b

!     Local variables
      integer tmp

      tmp = a
      a = b
      b = tmp

      return
      end
